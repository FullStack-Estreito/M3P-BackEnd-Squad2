using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories.Avaliacao
{
    public interface IAvaliacaoRepository
    {
        public List<Avaliacao>? ObterTodos();
        public Avaliacao? ObterPorId(int codigo);
        public void Delete(int id);
        public void Atualizar(Avaliacao avaliacao);
        public void Adicionar(Avaliacao avaliacao);
    }
}