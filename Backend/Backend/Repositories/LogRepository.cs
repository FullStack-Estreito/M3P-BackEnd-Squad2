using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class LogRepository : ILogRepository
    {
        // Injeção de dependência do banco de dados
        private readonly LabSchoolContext _context;

        public LogRepository(LabSchoolContext context)
        {

            _context = context;
        }

        public void Adicionar(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        // Obter todos
        public List<Log>? ObterTodos()
        {
            return  _context.Logs.ToList();
        }
    }
}