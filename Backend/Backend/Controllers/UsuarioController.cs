using System;
using Backend.Context;
using Backend.Models;
using Backend.DtoEntrada;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Mapper;
using AutoMapper;
using Backend.DtoSaida;
using Backend.Output;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using Backend.Service;

namespace Backend.Controllers;

[ApiController]
[Route("UsuarioController")]
public class UsuarioController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly LabSchoolContext _context;

    private readonly UsuarioRepository _usuarioRepository;
    public UsuarioController(UsuarioRepository usuarioRepository, IMapper mapper, LabSchoolContext context)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
        _context = context;
    }


    [Authorize]
    [HttpGet("/Listar")]
    public IActionResult Listar()
    {
        var user = _usuarioRepository.ObterAdmins();
        return Ok(user);
    }

    [HttpGet("/ObterUsuarioPorId/{id}")]
    public IActionResult Obter(int id)
    {
        var user = _usuarioRepository.ObterPorId(id);
        if (user != null)
            return Ok(user);
        else
            return NotFound("Nada Consta");
    }

    [HttpGet("/ListarEmpresas")]
    public IActionResult ListarEmpresa()
    {
        var empresa = _usuarioRepository.ObterEmpresas();
        return Ok(empresa);
    }

    [HttpGet("/ListarEnd")]
    public IActionResult ListarEnd()
    {
        var end = _usuarioRepository.ObterEnd();
        return Ok(end);
    }



    [HttpPost]
    [Route("/CriarUsuário")]
    public IActionResult Cadastrar([FromBody] UsuarioInput user)
    {
        var usuario = _mapper.Map<Usuario>(user);
        _usuarioRepository.Criar(usuario);
        var usuarioSaida = _mapper.Map<UsuarioOutput>(usuario);
        _usuarioRepository.SalvarLogs("salvar", usuario.Id);
        return CreatedAtAction(
            nameof(UsuarioController.Listar),
            new { id = usuarioSaida.Id },
            usuarioSaida
        );
    }

    [HttpPut("/Update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<UsuarioOutput> Put(int id, [FromBody] UsuarioInput user)
    {
        try
        {
            var usuario = _context.Usuarios.Where(w => w.Id == id).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound(new { erro = "Registro não encontrado" });
            }

            usuario = _mapper.Map(user, usuario);
            var usuarioSaida = _mapper.Map<UsuarioOutput>(usuario);
            _usuarioRepository.Atualizar(usuario);
            return Ok(usuarioSaida);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }


    [HttpPost]
    [Route("/CriarEndereco")]
    public IActionResult CadastrarEnd([FromBody] EnderecoInput end)
    {
        var endereco = _mapper.Map<Endereco>(end);
        _usuarioRepository.CriarEndereco(endereco);
        var enderecoOutPut = _mapper.Map<EnderecoOutPut>(endereco);

        return CreatedAtAction(
            nameof(UsuarioController.ListarEnd),
            new { id = enderecoOutPut.Id },
            enderecoOutPut
        );
    }


    [HttpPost]
    [Route("/CriarEmpresa")]
    public IActionResult CadastrarEmpresa([FromBody] EmpresaInput enter)
    {

        var empresa = _mapper.Map<Empresa>(enter);
        _usuarioRepository.CriarEmpresa(empresa);
        var enterSaida = _mapper.Map<EmpresaOutPut>(empresa);

        return CreatedAtAction(
            nameof(UsuarioController.ListarEmpresa),
            new { id = empresa.Id },
            empresa
        );
    }
    // [Authorize]
    [HttpDelete("/DeletarUsuario/{id}")]
    public IActionResult Delete(int id)
    {
        var user = _usuarioRepository.ObterPorId(id);
        if (user == null)
        {
            return NotFound("Not Found");
        }
        _usuarioRepository.Excluir(id);
        return NoContent();
    }

    [HttpPost("/Login")]
    public IActionResult SignUp([FromBody] Login login)
    {

        var logado = _usuarioRepository.Logar(login);
        if (logado)
        {
            var token = TokenService.GerarTokem(login);
            return Ok(token);
        }
        else
            return BadRequest("Login Incorreto");
    }


    [HttpPatch("/resetar")]
    public IActionResult MudarSenha(string email, ResetarSenhaInput senha)
    {

        var up = _usuarioRepository?.Resetar(email, senha);
        return Ok(up);
    }

    // [Authorize]
    [HttpGet("/ListarLogs")]
    public IActionResult ListarLogs()
    {
        var log = _usuarioRepository.ExibirLogs();
        return Ok(log);
    }

}


