using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTO.Avaliacao
{
    public class AvaliacaoReadDTO
	{
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public string Data { get; set; }

        public double Pontuacao_Maxima { get; set; }

        public double Nota { get; set; }

        public int Professor_Id { get; set; }

        public int Aluno_Id { get; set; }
    }
}

