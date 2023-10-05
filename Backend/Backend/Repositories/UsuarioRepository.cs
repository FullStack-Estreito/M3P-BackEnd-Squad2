using System;
using Backend.Context;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UsuarioRepository
{
    private readonly LabSchoolContext _context;

    public UsuarioRepository(LabSchoolContext context)
    {
        _context = context;
    }

    public List<Administrador> ObterAdmins()
    {
        return _context.Administradores.ToList();
    }

    public List<Endereco> ObterEnd()
    {
        return _context.Enderecos.ToList();
    }

    public void Criar(Administrador admin)
    {
        _context.Administradores.Add(admin);
        _context.SaveChanges();
    }

    public void CriarEndereco(Endereco end)
    {
        _context.Enderecos.Add(end);
        _context.SaveChanges();
    }





}

