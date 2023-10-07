
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.DTO.Exercicio
{
    public class ExercicioReadDTO
	{
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public string Data_Conclusao { get; set; }

        public int Professor_Id { get; set; }

        public int Aluno_Id { get; set; }

        public ExercicioAlunoReadDTO Aluno_Nome { get; set; }

        public ExercicioProfessorReadDTO Professor_Nome { get; set; }
    }

    public class ExercicioAlunoReadDTO
    {
        public string Nome { get; set; }
    }

    public class ExercicioProfessorReadDTO
    {
        public string Nome { get; set; }
    }
}

