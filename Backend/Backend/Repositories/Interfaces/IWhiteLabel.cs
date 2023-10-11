using Backend.Models;

namespace Backend.Repositories.Interfaces
{
	public interface IWhiteLabel
	{
        public List<Empresa>? ObterTodos();
        public Empresa? ObterPorEmpresa (string empresa);
        public void Adicionar (Empresa empresa);
        public void Atualizar(Empresa empresa);
    }
}