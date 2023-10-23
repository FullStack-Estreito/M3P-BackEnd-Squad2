using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.DTO.Atendimentos
{
    public class AtendimentosCreateDTO
    {
        public string Data { get; set; }

        public string Descricao { get; set; }

        public int Aluno_id { get; set; }

        public int Pedagogo_id { get; set; }

    }
}
