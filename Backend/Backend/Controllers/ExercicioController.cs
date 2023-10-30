using System;
using System.Net;
using AutoMapper;
using Backend.DTO.Avaliacao;
using Backend.DTO.Exercicio;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Backend.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/exercicios")]
    public class ExercicioController : ControllerBase
	{

        // Injeção de dependência do repositório e mapper
        private readonly IExercicioRepository _exercicioRepository;
        private readonly IMapper _mapper;

        public ExercicioController(IExercicioRepository exercicioRepository, IMapper mapper)
		{
            _exercicioRepository = exercicioRepository;
            _mapper = mapper;
        }

        // Endpoints
        [HttpGet]
        public ActionResult<IEnumerable<ExercicioReadDTO>> GetAll()
        {
            try
            {
                List<Exercicio> retorno;

                retorno = _exercicioRepository.ObterTodos();

                if (retorno.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<List<ExercicioReadDTO>>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<ExercicioReadDTO> GetById(int id)
        {
            try
            {
                var retorno = _exercicioRepository.ObterPorId(id);

                if (retorno == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<ExercicioReadDTO>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("aluno/{id}/historico")]
        public ActionResult<ExercicioReadDTO> GetExerciciosById(int id)
        {
            try
            {
                var retorno = _exercicioRepository.ObterExerciciosPorAluno(id);

                if (retorno == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }
                else if (!retorno.Any()){
                    return NotFound("O aluno nao possui nenhum registro.");

                }

                var retornoDTO = _mapper.Map<List<ExercicioReadDTO>>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public ActionResult<ExercicioReadDTO> Post([FromBody] ExercicioCreateDTO exercicioCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var novoExercicio = _mapper.Map<Exercicio>(exercicioCreateDTO);

                // Validando os dados informados
                var exercicioValidator = new ExercicioValidator();
                var validatorResult = exercicioValidator.Validate(novoExercicio);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _exercicioRepository.Adicionar(novoExercicio);

                // Mapeando o retorno para o ReadDTO
                var novoExercicioRead = _mapper.Map<ExercicioReadDTO>(novoExercicio);

                return Created("Exercicio criado com sucesso!", novoExercicioRead);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ExercicioReadDTO> Put(int id, [FromBody] ExercicioUpdateDTO exercicioUpdateDTO)
        {
            try
            {
                var exercicio = _exercicioRepository.ObterPorId(id);

                if (exercicio == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                // Mapeando para a model
                exercicio = _mapper.Map(exercicioUpdateDTO, exercicio);

                // Validando os dados informados
                var exercicioValidator = new ExercicioValidator();
                var validatorResult = exercicioValidator.Validate(exercicio);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _exercicioRepository.Atualizar(exercicio);

                // Mapeando o retorno para o ReadDTO
                var exercicioAtualizadoRead = _mapper.Map<ExercicioReadDTO>(exercicio);
                return Ok(new
            {
                Mensagem = "Exercicio atualizado com sucesso",
                Exercicio = exercicioAtualizadoRead
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
                var exercicio = _exercicioRepository.ObterPorId(id);

                if (exercicio == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                _exercicioRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

