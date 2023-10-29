using Backend.DTO.Empresa;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
	public interface IEmpresaRepository
	{
        public Empresa? ObterPorId (int id);
        public void Adicionar (Empresa empresa);
        public void Atualizar(Empresa empresa);
    }
}