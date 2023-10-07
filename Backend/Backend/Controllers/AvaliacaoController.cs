using System;
using AutoMapper;
using Backend.DTO.Avaliacao;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	public class AvaliacaoController : ControllerBase
    {

		// Injeção de dependência do repositório
		private readonly AvaliacaoRepository _avaliacaoRepository;
        private readonly IMapper _mapper;

        public AvaliacaoController(AvaliacaoRepository avaliacaoRepository, IMapper mapper)
		{
			_avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        // Endpoints
        [HttpGet]
        [Route("api/avaliacao")]
        public IActionResult Obter()
        {
            try
            {
                List<Avaliacao> resposta;

                resposta = _avaliacaoRepository.ObterTodos();

                if (resposta.Count() == 0)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }

                var respostaDTO = _mapper.Map<List<AvaliacaoReadDTO>>(resposta);

                return Ok(respostaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

