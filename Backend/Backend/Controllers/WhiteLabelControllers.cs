using System.Net;
using Backend.DTO.WhiteLabel;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhiteLabelController : ControllerBase
    {
        private readonly IWhiteLabel _whiteLabelRepository;
        public WhiteLabelController(IWhiteLabel whiteLabelRepository)
        {
            _whiteLabelRepository = whiteLabelRepository;
        }

        //Endpoints
        [HttpPost]
        public ActionResult Post([FromBody] WhiteLabelDTO whiteLabelDto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var empresa = new Empresa()
                {
                    Nome_Empresa = whiteLabelDto.Nome_Empresa,
                    Slogan = whiteLabelDto.Slogan,
                    Paleta_Cores = whiteLabelDto.Palheta_Cores,
                    Logotipo_URL = whiteLabelDto.Imagem_Logotipo,
                    Demais_Infos = whiteLabelDto.Demais_Informacoes,
                };

                var empresaValidator = new EmpresaValidator();
                var validatorResult = empresaValidator.Validate(empresa);

                if (validatorResult.IsValid == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validatorResult.Errors);
                }
                else
                {
                    _whiteLabelRepository.Adicionar(empresa);

                    return StatusCode(HttpStatusCode.Created.GetHashCode(), empresa);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var empresa = _whiteLabelRepository.ObterTodos();

                if (empresa == null)
                {
                    return NotFound("Nenhum registro encontrado no banco de dados.");
                }
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex);
            }
        }
        [HttpPut("{nome_Empresa}")]
        public IActionResult Put(string nome_Empresa, [FromBody] WhiteLabelDTO dto)
        {
            var whitelabel = _whiteLabelRepository.ObterPorEmpresa(nome_Empresa);

            if (whitelabel == null)
            {
                return NotFound($"A(O) {nome_Empresa} não foi encontrado ou não existe no banco de dados.");
            }

            whitelabel.Nome_Empresa = dto.Nome_Empresa;
            whitelabel.Slogan = dto.Slogan;
            whitelabel.Paleta_Cores = dto.Palheta_Cores;
            whitelabel.Logotipo_URL = dto.Imagem_Logotipo;
            whitelabel.Demais_Infos = dto.Demais_Informacoes;

            _whiteLabelRepository.Atualizar(whitelabel);

            return Ok(whitelabel);
        }
    }
}
