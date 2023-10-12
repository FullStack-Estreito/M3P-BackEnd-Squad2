
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class WhiteLabelRepository : IWhiteLabel
	{
        // Injeção de dependência do banco de dados
        private readonly LabSchoolContext _context;

        public WhiteLabelRepository (LabSchoolContext context)
        {
            _context = context;
        }
        public List<Empresa>? ObterTodos()
        {
           return _context.Empresas.ToList();
        }
        public Empresa? ObterPorEmpresa(string empresa)
        {
            return _context.Empresas.FirstOrDefault(x => x.Nome_Empresa.Equals(empresa));
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