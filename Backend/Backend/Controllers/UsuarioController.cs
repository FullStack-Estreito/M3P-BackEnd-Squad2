// using System;
// using Backend.Context;
// using Backend.Models;
// using Backend.Repositories;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace Backend.Controllers;

// [ApiController]
// [Route("UsuarioController")]
// public class UsuarioController : ControllerBase
// {

//     private readonly UsuarioRepository _usuarioRepository;

//     public UsuarioController(UsuarioRepository usuarioRepository)
//     {
//         _usuarioRepository = usuarioRepository;
//     }



//     [HttpGet("/Listar")]
//     public IActionResult Listar()
//     {
//         var admin = _usuarioRepository.ObterAdmins();
//         return Ok(admin);
//     }

//     [HttpGet("/ListarEnd")]
//     public IActionResult ListarEnd()
//     {
//         var end = _usuarioRepository.ObterEnd();
//         return Ok(end);
//     }



//     [HttpPost]
//     [Route("/CriarUsuário")]
//     public IActionResult Cadastrar([FromBody] Administrador admin)
//     {
//         _usuarioRepository.Criar(admin);

//         return CreatedAtAction(
//             nameof(UsuarioController.Listar),
//             new { id = admin.Id },
//             admin
//         );
//     }


//     [HttpPost]
//     [Route("/CriarEndereco")]
//     public IActionResult CadastrarEnd([FromBody] Endereco end)
//     {
//         _usuarioRepository.CriarEndereco(end);

//         return CreatedAtAction(
//             nameof(UsuarioController.Listar),
//             new { id = end.Id },
//             end
//         );
//     }
// }


