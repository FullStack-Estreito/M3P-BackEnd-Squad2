using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface ILogRepository
    {
        public List<Log>? ObterTodos();
          public void Adicionar(Log log);
    }
}