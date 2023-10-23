using System;
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Backend.Repositories
{
    public class AtendimentosRepository : IAtendimentosRepository
    {
        // Injeção de dependência do banco de dados
        private readonly LabSchoolContext _context;

        public AtendimentosRepository(LabSchoolContext context)
        {
            _context = context;
        }


        public List<Atendimento>? ObterTodos()
        {
            return _context.Atendimentos
                .Include(item => item.Pedagogo)
                .Include(item => item.Aluno)
                .ToList();
        }

        public Atendimento ObterPorId(int id)
        {
            return _context.Atendimentos
                .Include(item => item.Pedagogo)
                .Include(item => item.Aluno)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Delete(int id)
        {
            var atendimento = _context.Atendimentos.FirstOrDefault(x => x.Id.Equals(id));

            _context.Atendimentos.Remove(atendimento);
            _context.SaveChanges();
        }

        public void Atualizar(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            _context.SaveChanges();
        }

        public void Adicionar(Atendimento atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges();
        }
    }
}
