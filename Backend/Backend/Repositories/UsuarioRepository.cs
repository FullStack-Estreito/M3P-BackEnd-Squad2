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

    public UsuarioRepository(LabSchoolContext context)
    {
        _context = context;
    }

    public List<Usuario> ObterAdmins()
    {
        return _context.Usuarios.ToList();
    }

    public List<Endereco> ObterEnd()
    {
        return _context.Enderecos.ToList();
    }

    public List<Empresa> ObterEmpresas()
    {
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
        _context.SaveChanges();
    }

    public void Atualizar(Usuario users)
    {

        _context.Usuarios.Update(users);
        _context.SaveChanges();
    }


    public void CriarEmpresa(Empresa enter)
    {
        _context.Empresas.Add(enter);
        _context.SaveChanges();
    }

    public Usuario? ObterPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));
    }

    public void Excluir(int id)
    {
        var user = ObterPorId(id);
        if (user != null)
        {
            _context?.Usuarios?.Remove(user);
            _context?.SaveChanges();
        }

    }

    public bool Logar(string email, string senha)
    {

        var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
        var testeSenha = _context.Usuarios.FirstOrDefault(x => x.Senha.Equals(senha));

        if (testeEmail != null && testeSenha != null)
            return true;
        else
            return false;
    }

    public string SalvarLogs(Log logs)
    {

        var logsUsuarios = "O " + logs.Usuario_Id + " efetuou " + logs.Acao + " na data: "
        + logs.Data + ".";

        _context.Logs.Add(logs);
        _context.SaveChanges();
        return logsUsuarios;

    }

}



