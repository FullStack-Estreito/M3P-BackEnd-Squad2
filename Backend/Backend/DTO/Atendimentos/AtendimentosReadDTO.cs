using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.DTO.Atendimentos
{
    public class AtendimentosReadDTO
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public string Descricao { get; set; }

        public int Aluno_id { get; set; }

        public int Pedagogo_id { get; set; }

        public AtendimentoAlunoReadDTO Aluno_nome { get; set; }

        public AtendimentoPedagogoReadDTO Pedagogo_nome { get; set; }
    }


    public class AtendimentoAlunoReadDTO
    {
        public string Nome { get; set; }
    }

    public class AtendimentoPedagogoReadDTO
    {
        public string Nome { get; set; }
    }
}
