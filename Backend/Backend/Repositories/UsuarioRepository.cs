using System;
using System.Linq;
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    // Injeção de dependência do banco de dados
    private readonly LabSchoolContext _context;

    public UsuarioRepository(LabSchoolContext context)
    {

        _context = context;
    }

    // Obter todos
    public List<Usuario> ObterTodos(int empresaId, string tipo = null, string nome = null, string telefone = null, string cpf = null)
    {
        var usuarios = _context.Usuarios.Where(u => u.Empresa_Id == empresaId).ToList();

        if (!string.IsNullOrEmpty(tipo))
        {
            usuarios = usuarios.Where(u => u.Tipo == tipo).ToList();
        }

        if (!string.IsNullOrEmpty(nome))
        {
            usuarios = usuarios.Where(u => u.Nome.Contains(nome)).ToList();
        }

        if (!string.IsNullOrEmpty(telefone))
        {
            usuarios = usuarios.Where(u => u.Telefone == telefone).ToList();
        }

        if (!string.IsNullOrEmpty(cpf))
        {
            usuarios = usuarios.Where(u => u.CPF == cpf).ToList();
        }

        return usuarios;
    }

    // Obter por id
    public Usuario? ObterPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));
    }

    // Obter por email
    public Usuario? ObterPorEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
    }

    // Adicionar
    public void Adicionar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    // Deletar
    public void Delete(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(x => x.Id.Equals(id));

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
    }

    // Atualizar
    public void Atualizar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    // Resetar senha
    public void ResetarSenha(Usuario usuario)
    {
        usuario.Senha = "0000";
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    public bool Logar(Login login)
    {

        var usuario = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(login.Email));

        if (usuario != null)
        {
            if (login.Senha == usuario.Senha)
            {
                _context.Logins.Add(login);
                _context.SaveChanges();
            }
            return true;
        }
        else
            return false;
    }

    public List<Usuario>? Listar()
    {
        return _context.Usuarios.ToList();
    }

}



// public Usuario Resetar(string email, ResetarSenhaInput senha)
// {
//     var testeEmail = _context.Usuarios.FirstOrDefault(x => x.Email.Equals(email));
//     _context.Usuarios?.Remove(testeEmail);
//     testeEmail.Senha = senha.Senha;
//     _context.Usuarios?.Update(testeEmail);
//     SalvarLogs("Resetar Senha", idUsuario);
//     _context.SaveChanges();
//     return testeEmail;
// }


// public void Atualizar(int id, UsuarioCompleto users)
// {
//     var usuario = _context.UsuarioCompleto.Where(w => w.Id == id).FirstOrDefault();
//     _context.UsuarioCompleto?.Remove(usuario);
//     users.Id = id;
//     _context.UsuarioCompleto?.Update(users);
//     _context.SaveChanges();
// }



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


// var testeEmail = _context.UsuarioCompleto.FirstOrDefault(x => x.Email.Equals(login.Email));
// var testeSenha = _context.UsuarioCompleto.FirstOrDefault(x => x.Senha.Equals(login.Senha));

// if (testeEmail != null && testeSenha != null)
// {
//     _context.Logins.Add(login);
//     _context.SaveChanges();
//     SalvarLogs("Logar", testeEmail.Id);
//     return true;
// }







