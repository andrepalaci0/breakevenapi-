namespace breakevenApi.Domain.Services.DTOs.Agenda
{
    public class AgendaDTO
    {
        public long IdMedico { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string DiaDaSemana { get; set; }

        public AgendaDTO(long idMedico, string horaInicio, string horaFim, string diaDaSemana)
        {
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            DiaDaSemana = diaDaSemana;
        }
    }
}
