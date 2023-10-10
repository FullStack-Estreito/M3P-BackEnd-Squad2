using System;
using System.Linq;
using Backend.Context;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;

namespace Backend.Repositories;

public class UsuarioRepository
{
    private readonly LabSchoolContext _context;
    private bool y;

    private int idUsuario { get; set; }
    public UsuarioRepository(LabSchoolContext context)
    {

        _context = context;
    }

    public List<Usuario> ObterAdmins()
    {
        Usuario user = new Usuario();
        // SalvarLogs("Listar usuário por ", user.Id);
        return _context.Usuarios.ToList();
    }

    public List<Endereco> ObterEnd()
    {
        Usuario user = new Usuario();
        // SalvarLogs("Obter endereço por id", user.Id);
        return _context.Enderecos.ToList();
    }

    public List<Empresa> ObterEmpresas()
    {
        // Usuario user = new Usuario();
        // SalvarLogs("Obter Empresas", idUsuario);
        return _context.Empresas.ToList();
    }


    public void Criar(Usuario users)
    {
        _context.Usuarios.Add(users);

        _context.SaveChanges();
    }

    public void CriarEndereco(Endereco end)
    {
        _context.Enderecos.Add(end);
        // SalvarLogs("Criar endereço ", end.Id);
        _context.SaveChanges();
    }

    public void Atualizar(Usuario users)
    {

        _context.Usuarios.Update(users);
        SalvarLogs("Atualizar usuário por id", users.Id);
        _context.SaveChanges();
    }


    public void CriarEmpresa(Empresa enter)
    {
        _context.Empresas.Add(enter);
        // SalvarLogs("Criar empresa ", 3);
        _context.SaveChanges();
    }

    public Usuario? ObterPorId(int id)
    {
        // SalvarLogs("Obter usuário por id", id);
        return _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));
    }

    public void Excluir(int id)
    {
        var user = ObterPorId(id);
        if (user != null)
        {
            _context?.Usuarios?.Remove(user);
            // SalvarLogs("Excluir usuário por id", user.Id);
            _context?.SaveChanges();
        }
    }

    public bool Logar(Login login)
    {

        var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(login.Email));
        var testeSenha = _context.Usuarios.FirstOrDefault(x => x.Senha.Equals(login.Senha));

        if (testeEmail != null && testeSenha != null)
        {
            _context.Login.Add(login);
            _context.SaveChanges();
            SalvarLogs("Logar", testeEmail.Id);
            return true;
        }
        else
            return false;
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
        // SalvarLogs("Listar ", user.Id);
        return _context.Logs.ToList();
    }


}



