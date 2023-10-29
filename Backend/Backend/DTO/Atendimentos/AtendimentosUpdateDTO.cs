using System;
namespace Backend.DTO.Atendimentos
{
    public class AtendimentosUpdateDTO
    {
        public int Id { get; set;}

        public string Data { get; set; }

        public string Descricao { get; set; }

        public int id_Aluno { get; set; }

        public int id_Pedagogo { get; set; }
    }
}
