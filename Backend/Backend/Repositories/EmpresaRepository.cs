
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
	{
        // Injeção de dependência do banco de dados
        private readonly LabSchoolContext _context;

        public EmpresaRepository (LabSchoolContext context)
        {
            _context = context;
        }
       
        public Empresa? ObterPorId (int id)
        {
             return _context.Empresas.FirstOrDefault(x => x.Id.Equals(id));;
        }
        public void Adicionar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }
        public void Atualizar(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
        }
    }
}