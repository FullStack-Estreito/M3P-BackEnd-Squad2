namespace Backend.DTO.Empresa;

public class EmpresaReadDTO
{
        public int Id { get; set; }
        public string Nome_Empresa { get; set; }

        public string Slogan { get; set; }

        public string Paleta_Cores { get; set; }

        public string Logotipo_URL { get; set; }

        public string Demais_Infos { get; set; }
}