using System;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
	public interface IExercicioRepository
	{
        public List<Exercicio>? ObterTodos();

        public Exercicio? ObterPorId(int id);

        public void Delete(int id);

        public void Atualizar(Exercicio exercicio);

        public void Adicionar(Exercicio exercicio);

        public List<Exercicio>? ObterExerciciosPorAluno(int alunoId);
    }
}

