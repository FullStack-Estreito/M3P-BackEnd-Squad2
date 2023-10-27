using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuario>? ObterTodos(int empresaId, string tipo , string nome, string telefone, string cpf);

        public Usuario? ObterPorId(int id);

        public Usuario? ObterPorEmail(string email);

        public void Delete(int id);

        public void Atualizar(Usuario usuario);

        public void Adicionar(Usuario usuario);

        public void ResetarSenha(Usuario usuario);
    }
}