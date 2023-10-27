using System;
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        // Injeção de dependência do banco de dados
        private readonly LabSchoolContext _context;

        public ExercicioRepository(LabSchoolContext context)
        {
            _context = context;
        }


        public List<Exercicio>? ObterTodos()
        {
            return _context.Exercicios
                .Include(item => item.Professor)
                .Include(item => item.Aluno)
                .ToList();
        }

        public Exercicio ObterPorId(int id)
        {
            return _context.Exercicios
                .Include(item => item.Professor)
                .Include(item => item.Aluno)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Delete(int id)
        {
            var exercicio = _context.Exercicios.FirstOrDefault(x => x.Id.Equals(id));

            _context.Exercicios.Remove(exercicio);
            _context.SaveChanges();
        }

        public void Atualizar(Exercicio exercicio)
        {
            _context.Exercicios.Update(exercicio);
            _context.SaveChanges();
        }

        public void Adicionar(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            _context.SaveChanges();
        }

        public List<Exercicio>? ObterExerciciosPorAluno(int alunoId)
        {
            return _context.Exercicios
                .Where(e => e.Aluno_Id == alunoId)
                .ToList();
        }
    }
}

