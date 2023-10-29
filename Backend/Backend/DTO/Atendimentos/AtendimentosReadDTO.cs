using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.DTO.Atendimentos
{
    public class AtendimentosReadDTO
    {
        public int Id { get; set;}

        public string Data { get; set; }

        public string Descricao { get; set; }

        public int id_Aluno { get; set; }

        public int id_Pedagogo { get; set; }
    }
}
