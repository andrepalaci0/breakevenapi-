namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class HorarioDTO
    {
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }

        public bool Livre { get; set; }

        public HorarioDTO(TimeOnly inicio, TimeOnly fim, bool livre)
        {
            HoraInicio = inicio;
            HoraFim = fim;
            Livre = livre;
        }

        //será considerado que cada consulta tem em média 30 minutos de duração



    }
}
