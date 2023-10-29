using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; 
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;



namespace Backend.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        // Injeção de dependência do banco de dados
        private readonly LabSchoolContext _context;

        public AvaliacaoRepository(LabSchoolContext context)
        {
            _context = context;
        }

        public List<Avaliacao>? ObterTodos()
        {
            return  _context.Avaliacoes
                .Include(item => item.Professor)
                .Include(item => item.Aluno)
                .ToList();
        }

        public Avaliacao ObterPorId(int id)
        {
            return _context.Avaliacoes
                .Include(item => item.Professor)
                .Include(item => item.Aluno)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Delete(int id)
        {
            var avaliacao = _context.Avaliacoes.FirstOrDefault(x => x.Id.Equals(id));
          
            _context.Avaliacoes.Remove(avaliacao);
            _context.SaveChanges();
        }

        public void Atualizar(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Update(avaliacao);
            _context.SaveChanges();
        }

        public void Adicionar(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();
        }
    }
}