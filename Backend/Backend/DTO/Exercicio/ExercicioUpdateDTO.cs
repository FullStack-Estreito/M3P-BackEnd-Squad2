﻿using System;
namespace Backend.DTO.Exercicio
{
	public class ExercicioUpdateDTO
	{
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public string Data_Conclusao { get; set; }

        public int Professor_id { get; set; }

        public int Aluno_id { get; set; }
    }
}

