
namespace Backend.DtoSaida;

public class LogOutPut
{
    public int Id { get; set; }
    public int Usuario_Id { get; set; }

    public string Acao { get; set; }

    public DateTime Data { get; set; }

    public string Detalhes { get; set; }
}