using System;
using Backend.Models;
namespace Backend.Repositories.Interfaces
{
    public interface IAtendimentosRepository
    {
        public List<Atendimento>? ObterTodos();

        public Atendimento? ObterPorId(int id);

        public void Delete(int id);

        public void Atualizar(Atendimento atendimento);

        public void Adicionar(Atendimento atendimento);
    }
}
