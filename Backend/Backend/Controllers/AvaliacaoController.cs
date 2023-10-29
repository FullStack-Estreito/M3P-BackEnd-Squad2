using System;
using AutoMapper;
using Backend.DTO.Avaliacao;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Validators;
using System.Net;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/avaliacao")]
    public class AvaliacaoController : ControllerBase
    {

        // Injeção de dependência do repositório e mapper
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IMapper _mapper;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        // Endpoints
        [HttpGet]
        public ActionResult<IEnumerable<AvaliacaoReadDTO>> GetAll()
        {
            try
            {
                List<Avaliacao> retorno;

                retorno = _avaliacaoRepository.ObterTodos();

                if (retorno.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<List<AvaliacaoReadDTO>>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<AvaliacaoReadDTO> GetById(int id)
        {
            try
            {
                var retorno = _avaliacaoRepository.ObterPorId(id);

                if (retorno == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<AvaliacaoReadDTO>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        public ActionResult<AvaliacaoReadDTO> Post([FromBody] AvaliacaoCreateDTO avaliacaoCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var novaAvaliacao = _mapper.Map<Avaliacao>(avaliacaoCreateDTO);

                // Validando os dados informados
                var avaliacaoValidator = new AvaliacaoValidator();
                var validatorResult = avaliacaoValidator.Validate(novaAvaliacao);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _avaliacaoRepository.Adicionar(novaAvaliacao);

                // Mapeando o retorno para o ReadDTO
                var novaAvaliacaoRead = _mapper.Map<AvaliacaoReadDTO>(novaAvaliacao);

                return Created("Avaliacao criada com sucesso!", novaAvaliacaoRead);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<AvaliacaoReadDTO> Put(int id, [FromBody] AvaliacaoUpdateDTO avaliacaoUpdateDTO)
        {
            try
            {
                var avaliacao = _avaliacaoRepository.ObterPorId(id);

                if (avaliacao == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                // Mapeando para a model
                avaliacao = _mapper.Map(avaliacaoUpdateDTO, avaliacao);

                // Validando os dados informados
                var avaliacaoValidator = new AvaliacaoValidator();
                var validatorResult = avaliacaoValidator.Validate(avaliacao);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _avaliacaoRepository.Atualizar(avaliacao);

                // Mapeando o retorno para o ReadDTO
                var avaliacaoAtualizadaRead = _mapper.Map<AvaliacaoReadDTO>(avaliacao);
                return Ok(new
                {
                    Mensagem = "Avaliacao atualizada com sucesso",
                    Avaliacao = avaliacaoAtualizadaRead
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var avaliacao = _avaliacaoRepository.ObterPorId(id);

                if (avaliacao == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                _avaliacaoRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

