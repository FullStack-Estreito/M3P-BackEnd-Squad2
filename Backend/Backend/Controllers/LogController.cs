using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTO.Log;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogController : ControllerBase
    {
        // Injeção de dependência do repositório e mapper
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogController(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogReadDTO>> GetAll()
        {
            try
            {
                List<Log> retorno;

                retorno = _logRepository.ObterTodos();

                if (retorno.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var retornoDTO = _mapper.Map<List<LogReadDTO>>(retorno);

                return Ok(retornoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        public ActionResult<LogReadDTO> Post([FromBody] LogCreateDTO logCreateDTO)
        {
            try
            {
                // Mapeando para a model
                var novoLog = _mapper.Map<Log>(logCreateDTO);

                // Validando os dados informados
                var logValidator = new LogValidator();
                var validatorResult = logValidator.Validate(novoLog);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }

                _logRepository.Adicionar(novoLog);

                // Mapeando o retorno para o ReadDTO
                var novoLogRead = _mapper.Map<LogReadDTO>(novoLog);

                return StatusCode(HttpStatusCode.Created.GetHashCode(), novoLogRead);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}