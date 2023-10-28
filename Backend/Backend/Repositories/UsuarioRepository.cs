using System;
using System.Collections;
using System.Linq;
using Backend.Context;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using Backend.Output;

namespace Backend.Repositories;

public class UsuarioRepository
{
    private readonly LabSchoolContext _context;

    private int idUsuario { get; set; }
    public UsuarioRepository(LabSchoolContext context)
    {

        _context = context;
    }

    public List<Usuario> ObterAdmins()
    {
        // SalvarLogs("Listar usuário por", 1);
        return _context.Usuarios.ToList();
    }

    public List<Endereco> ObterEnd()
    {
        // SalvarLogs("Obter endereço por id", 1);
        return _context.Enderecos.ToList();
    }


    public void Criar(Usuario users)
    {
        _context.Usuarios.Add(users);
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));

        // SalvarLogs("Excluiu", usuario.Nome, usuario.Id);
        _context.Usuarios?.Remove(usuario);
        _context.SaveChanges();

    }

    public void Atualizar(int id, Usuario users)
    {
        var usuario = _context.Usuarios.Where(w => w.Id == id).FirstOrDefault();
        _context.Usuarios?.Remove(usuario);
        users.Id = id;
        _context.Usuarios?.Update(users);
        _context.SaveChanges();
    }



    public Usuario? ObterPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));
    }

    public Endereco? ObterEndPorId(int id)
    {
        return _context.Enderecos.FirstOrDefault(x => x.Id.Equals(id));
    }

    public bool Logar(Login login)
    {
        var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(login.Email));
        if (testeEmail.Senha.Equals(login.Senha))
        {
            login.Tipo = testeEmail.Tipo;
            _context.Logins.Add(login);
            SalvarLogs("logou", testeEmail.Nome, testeEmail.Id);
            _context.SaveChanges();
            return true;
        }
        else
            return false;
    }


    public void SalvarLogs(string acao, string nome, int id)
    {

        var logs = new Log();
        logs.Usuario_Id = id;
        logs.Nome = nome;
        logs.Acao = acao;
        logs.Detalhes = "blá, blá";
        logs.Data = DateTime.Now;
        _context.Logs.Add(logs);
        _context.SaveChanges();
    }


    public List<Log> ExibirLogs()
    {
        // SalvarLogs("Listar ", 1);
        return _context.Logs.ToList();
    }

    public Usuario Resetar(string email, ResetarSenhaInput senha)
    {
        var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
        _context.Usuarios?.Remove(testeEmail);
        testeEmail.Senha = senha.Senha;
        _context.Usuarios?.Update(testeEmail);
        SalvarLogs("Resetar Senha", testeEmail.Nome, idUsuario);
        _context.SaveChanges();
        return testeEmail;
    }



}



