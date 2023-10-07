using AutoMapper;
using AtendimentoCadastroApi.DTO.Atendimento;
using AtendimentoCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoCadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly ILogger<AtendimentoController> _logger;
        private readonly AtendimentoCadastroDbContext _atendimentoCadastroDbContext;
        private readonly IMapper _mapper;
        
        public AtendimentoController(ILogger<AtendimentoController> logger, AtendimentoCadastroDbContext atendimentoCadastroDbContext, IMapper mapper)
        {
            _logger = logger;
            _atendimentoCadastroDbContext = atendimentoCadastroDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AtendimentoReadDTO> Post([FromBody] AtendimentoCreateDTO atendimentoCreateDTO)
        {
            try
            {
                var atendimentoModel = _mapper.Map<AtendimentoModel>(atendimentoCreateDTO);

                if (_atendimentoCadastroDbContext.AtendimentoModels.ToList().Exists(e => e.Email == atendimentoCreateDTO.EmailInformado))
                {
                    return Conflict(new { erro = "E-mail Cadastrado" });
                }

                _atendimentoCadastroDbContext.AtendimentoModels.Add(atendimentoModel);
                _atendimentoCadastroDbContext.SaveChanges();


                var atendimentoReadDTO = _mapper.Map<AtendimentoReadDTO>(atendimentoModel);

                return StatusCode(HttpStatusCode.Created.GetHashCode(), atendimentoReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<AtendimentoReadDTO>> Get([FromQuery] string? email)
        {
            try
            {
                List<AtendimentoModel> atendimentoModels;

                if (email.IsNullOrEmpty()) // email == null || email == "" 
                {
                    atendimentoModels = _atendimentoCadastroDbContext.AtendimentoModels
                                                         .Include(i => i.Detalhes)
                                                         .ToList();
                }
                else
                {
                    atendimentoModels = _atendimentoCadastroDbContext.AtendimentoModels
                                                         //.Where(w => w.Email.Equals(email!))
                                                         .Where(w => w.Email == email)
                                                         .Include(i => i.Detalhes).ToList();
                }

                var atendimentoReadDTO = _mapper.Map<List<AtendimentoReadDTO>>(atendimentoModels);
                return Ok(atendimentoReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AtendimentoReadDTO> Get(int id)
        {
            try
            {
                var atendimentoModel = _atendimentoCadastroDbContext.AtendimentoModels.Find(id);

                if (atendimentoModel == null)
                {
                    return NotFound(new { erro = "Atendimento não encontrada" });
                }

                var atendimentoReadDTO = _mapper.Map<AtendimentoReadDTO>(atendimentoModel);
                return Ok(atendimentoReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AtendimentoReadDTO> Put(int id, [FromBody] AtendimentoUpdateDTO atendimentoUpdateDTO)
        {
            try
            {
                var atendimentoModel = _atendimentoCadastroDbContext.AtendimentoModels.Where(w => w.Id == id).FirstOrDefault();

                if (atendimentoModel == null)
                {
                    return NotFound(new { erro = "Registro não encontrado" });
                }

                atendimentoModel = _mapper.Map(atendimentoUpdateDTO, atendimentoModel);

                _atendimentoCadastroDbContext.AtendimentoModels.Update(atendimentoModel);
                _atendimentoCadastroDbContext.SaveChanges();
                var atendimentoReadDTO = _mapper.Map<AtendimentoReadDTO>(atendimentoModel);

                return Ok(atendimentoReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {
                var atendimentoModel = _atendimentoCadastroDbContext.AtendimentoModels.Where(w => w.Id == id).FirstOrDefault();

                if (atendimentoModel == null)
                {
                    return NotFound(new { erro = "Registro n�o encontrado" });
                }

                if (atendimentoModel.Detalhes != null && atendimentoModel.Detalhes!.Count > 0)
                {
                    return NotFound(new { erro = "Existe Detalhes relacionados com a atendimento" });
                }
                                
                if (atendimentoModel == null)
                {
                    return NotFound(new { erro = "Registro não encontrado" });
                }

                if (atendimentoModel.Detalhes != null && atendimentoModel.Detalhes!.Count > 0)
                {
                    return NotFound(new { erro = "Existe Detalhes relacionados com a atendimento" });
                }

                _atendimentoCadastroDbContext.AtendimentoModels.Remove(atendimentoModel);
                _atendimentoCadastroDbContext.SaveChanges();

                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}