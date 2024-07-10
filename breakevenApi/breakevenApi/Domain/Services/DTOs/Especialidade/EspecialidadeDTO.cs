namespace breakevenApi.Domain.Services.DTOs.Especialidade;

public class EspecialidadeDTO
{
    public long Codigo { get; set; }
    public int Indice { get; set; }
    public string Nome { get; set; }

    public EspecialidadeDTO(long codigo, int indice, string nome)
    {
        Codigo = codigo;
        Indice = indice;
        Nome = nome;
    }
}