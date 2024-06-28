namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class GetHorarioLivreDTO
    {
        public long IdMedico { get; set; }
        public string Data { get; set; }

        public GetHorarioLivreDTO(long idMedico, string data)
        {
            IdMedico = idMedico;
            Data = data;
        }
    }
}
