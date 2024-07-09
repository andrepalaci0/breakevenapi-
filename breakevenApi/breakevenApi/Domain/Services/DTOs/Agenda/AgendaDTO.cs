namespace breakevenApi.Domain.Services.DTOs.Agenda
{
    public class AgendaDTO
    {
        public long IdMedico { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public string DiaDaSemana { get; set; }

        public AgendaDTO()
        {
            
        }

        public AgendaDTO(long idMedico, TimeOnly horaInicio, TimeOnly horaFim, string diaDaSemana)
        {
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            DiaDaSemana = diaDaSemana;
        }
    }
}
