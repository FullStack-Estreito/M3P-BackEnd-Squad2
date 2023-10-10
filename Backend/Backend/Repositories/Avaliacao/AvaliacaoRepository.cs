// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Backend.Context;
// using Backend.Models;

// namespace Backend.Repositories.Avaliacao
// {
//     public class AvaliacaoRepository : IAvaliacaoRepository
//     {

//         private readonly LabSchoolContext _context;

//         // Injeção de dependência do banco de dados
//         public AvaliacaoRepository(LabSchoolContext context)
//         {
//             _context = context;
//         }

//         // OBTER LISTA COMPLETA OU OPCIONALMENTE PELO PARÂMETRO SITUAÇÃO
//         public List<Avaliacao>? ObterTodos()
//         {
//             return _context.Avaliacoes.ToList();
//         }

//         // OBTER POR ID
//         public Atendimento ObterPorId(int id)
//         {
//             return _context.Atendimentos.FirstOrDefault(x => x.Aluno_Id.Equals(codigo));
//         }

//         // EXCLUIR
//         public bool Delete(int codigo)
//         {
//             var aluno = ObterPorCodigo(codigo);
//             if (aluno == null)
//             {
//                 return false;
//             }
//             _context.Alunos.Remove(aluno);
//             _context.SaveChanges();
//             return true;
//         }

//         // ATUALIZAR
//         public void Atualizar(Aluno aluno)
//         {
//             _context.Update(aluno);
//             _context.SaveChanges();
//         }

//         // ADICIONAR
//         public void Adicionar(Aluno aluno)
//         {
//             _context.Alunos.Add(aluno);
//             _context.SaveChanges();
//         }

//         // CHECA SE HÁ ALGUM CPF JÁ REGISTRADO NO BANCO DE DADOS
//         public bool CPF_Unico(string valor_cpf)
//         {
//             re
//     }
//     }
// }