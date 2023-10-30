using System.Net;
using AutoMapper;
using Backend.Models;
using Backend.DTO.Atendimentos;
using Backend.Repositories.Interfaces;
using Backend.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/atendimentos")]
    public class AtendimentosController : ControllerBase
    {
        // Injeção de dependência do repositório e mapper
        private readonly IAtendimentosRepository _atendimentosRepository;
        private readonly IMapper _mapper;

        public AtendimentosController(IAtendimentosRepository atendimentosRepository, IMapper mapper)
        {
            _atendimentosRepository = atendimentosRepository;
            _mapper = mapper;
        }

        // Endpoints
        [HttpGet]
        public ActionResult<IEnumerable<AtendimentosReadDTO>> GetAll()
        {
            try
            {
                List<Atendimento> retorno;

                retorno = _atendimentosRepository.ObterTodos();

                if (retorno.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<List<AtendimentosReadDTO>>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<AtendimentosReadDTO> GetById(int id)
        {
            try
            {
                var retorno = _atendimentosRepository.ObterPorId(id);

                if (retorno == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<AtendimentosReadDTO>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<AtendimentosReadDTO> Post([FromBody] AtendimentosCreateDTO atendimentosCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var novoAtendimentos = _mapper.Map<Atendimento>(atendimentosCreateDTO);

                // Validando os dados informados
                var atendimentosValidator = new AtendimentosValidator();
                var validatorResult = atendimentosValidator.Validate(novoAtendimentos);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _atendimentosRepository.Adicionar(novoAtendimentos);

                // Mapeando o retorno para o ReadDTO
                var novoAtendimentosRead = _mapper.Map<AtendimentosReadDTO>(novoAtendimentos);

                return Created("Atendimento criado com sucesso!", novoAtendimentosRead);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<AtendimentosReadDTO> Put(int id, [FromBody] AtendimentosUpdateDTO atendimentosUpdateDTO)
        {
            try
            {
                var atendimentos = _atendimentosRepository.ObterPorId(id);

                if (atendimentos == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                // Mapeando para a model
                atendimentos = _mapper.Map(atendimentosUpdateDTO, atendimentos);

                // Validando os dados informados
                var atendimentosValidator = new AtendimentosValidator();
                var validatorResult = atendimentosValidator.Validate(atendimentos);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _atendimentosRepository.Atualizar(atendimentos);

                // Mapeando o retorno para o ReadDTO
                var atendimentosAtualizadoRead = _mapper.Map<AtendimentosReadDTO>(atendimentos);
                return Ok(new
            {
                Mensagem = "Atendimento atualizado com sucesso",
                Atendimento = atendimentosAtualizadoRead
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
                var atendimentos = _atendimentosRepository.ObterPorId(id);

                if (atendimentos == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                _atendimentosRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
