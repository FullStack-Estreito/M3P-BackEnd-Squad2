using System;
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;

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
            return _context.Exercicios.ToList();
        }

        public Exercicio ObterPorId(int id)
        {
            return _context.Exercicios.FirstOrDefault(x => x.Id.Equals(id));
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
    }
}

