﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.DTO.Exercicio
{
	public class ExercicioCreateDTO
	{
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public string Data_Conclusao { get; set; }

        public int Professor_Id { get; set; }

        public int Aluno_Id { get; set; }
    }
}

