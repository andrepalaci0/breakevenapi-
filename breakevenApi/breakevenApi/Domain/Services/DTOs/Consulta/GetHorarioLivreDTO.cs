namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class GetHorarioLivreDTO
    {
        public long IdMedico { get; set; }
        public DateOnly Data { get; set; }

        public GetHorarioLivreDTO(long idMedico, DateOnly data)
        {
            IdMedico = idMedico;
            Data = data;
        }
    }
}
