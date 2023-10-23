using System;
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

    public List<UsuarioCompleto> ObterAdmins()
    {
        // SalvarLogs("Listar usuário por", 1);
        return _context.UsuarioCompleto.ToList();
    }

    public List<Endereco> ObterEnd()
    {
        // SalvarLogs("Obter endereço por id", 1);
        return _context.Enderecos.ToList();
    }

    public List<Empresa> ObterEmpresas()
    {
        SalvarLogs("Obter Empresas", 1);
        return _context.Empresas.ToList();
    }


    public void Criar(Usuario users)
    {
        _context.Usuarios.Add(users);
        _context.SaveChanges();
    }


    public void CriarEndereco(Endereco end)
    {
        // List<Endereco> endereco = new List<Endereco>();
        _context.Enderecos.Add(end);
        // SalvarLogs("Criar endereço", 1);
        _context.SaveChanges();
    }

    public Usuario Resetar(string email, ResetarSenhaInput senha)
    {
        var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
        _context.Usuarios?.Remove(testeEmail);
        testeEmail.Senha = senha.Senha;
        _context.Usuarios?.Update(testeEmail);
        SalvarLogs("Resetar Senha", idUsuario);
        _context.SaveChanges();
        return testeEmail;
    }


    public void Atualizar(int id, UsuarioCompleto users)
    {
        var usuario = _context.UsuarioCompleto.Where(w => w.Id == id).FirstOrDefault();
        _context.UsuarioCompleto?.Remove(usuario);
        users.Id = id;
        _context.UsuarioCompleto?.Update(users);
        _context.SaveChanges();
    }


    public void CriarEmpresa(Empresa enter)
    {
        _context.Empresas.Add(enter);
        SalvarLogs("Criar empresa ", 3);
        _context.SaveChanges();
    }

    public UsuarioCompleto? ObterPorId(int id)
    {
        // SalvarLogs("Obter usuário por id", id);
        return _context.UsuarioCompleto.FirstOrDefault(x => x.Id.Equals(id));
    }

    // public void Excluir(int id)
    // {
    //     var user = ObterPorId(id);
    //     if (user != null)
    //     {
    //         _context?.Usuarios?.Remove(user);
    //         SalvarLogs("Excluir usuário por id", user.Id);
    //         _context?.SaveChanges();
    //     }
    // }

    public bool Logar(Login login)
    {

        var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(login.Email));
        var testeSenha = _context.Usuarios.FirstOrDefault(x => x.Senha.Equals(login.Senha));

        if (testeEmail != null && testeSenha != null)
        {
            _context.Logins.Add(login);
            _context.SaveChanges();
            SalvarLogs("Logar", testeEmail.Id);
            return true;
        }
        else
            return false;
    }



    public void SalvarLogs(string acao, int id)
    {

        var logs = new Log();
        logs.Usuario_Id = id;
        logs.Acao = acao;
        logs.Detalhes = "blá, blá";
        logs.Data = DateTime.Now;
        _context.Logs.Add(logs);
        _context.SaveChanges();
    }


    public List<Log> ExibirLogs()
    {
        // Usuario user = new Usuario();
        SalvarLogs("Listar ", 1);
        return _context.Logs.ToList();
    }

    public void CriarUsuario(UsuarioCompleto usuarioCompleto)
    {
        _context.UsuarioCompleto.Add(usuarioCompleto);
        _context.SaveChanges();
    }



}



