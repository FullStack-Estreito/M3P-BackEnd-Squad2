﻿using System;
namespace Backend.DTO.Avaliacao
{
	public class AvaliacaoCreateDTO
	{
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public string Data { get; set; }

        public double Pontuacao_Maxima { get; set; }

        public double Nota { get; set; }

        public int Professor_Id { get; set; }
    }
}

