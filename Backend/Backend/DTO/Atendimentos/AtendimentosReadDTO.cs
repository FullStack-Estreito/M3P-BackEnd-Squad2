using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.DTO.Atendimentos
{
    public class AtendimentosReadDTO
    {
        public string Data { get; set; }

        public string Descricao { get; set; }

        public int Aluno_id { get; set; }

        public int Pedagogo_id { get; set; }
    }
}
