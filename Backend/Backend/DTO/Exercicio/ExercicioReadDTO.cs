
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.DTO.Exercicio
{
    public class ExercicioReadDTO
	{
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public string Data_Conclusao { get; set; }

        public int Professor_id { get; set; }

        public int Aluno_id { get; set; }

        public ExercicioAlunoReadDTO Aluno_nome { get; set; }

        public ExercicioProfessorReadDTO Professor_nome { get; set; }
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

