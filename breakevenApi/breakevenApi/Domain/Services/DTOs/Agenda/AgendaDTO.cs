namespace breakevenApi.Domain.Services.DTOs.Agenda
{
    public class AgendaDTO
    {
        public long IdMedico { get; set; }
        public string HoraInicio { get; set; }
        public string MinutoInicio { get; set; }

        public string HoraFim { get; set; }
        public string MinutoFim { get; set; }
        public string DiaDaSemana { get; set; }

        public AgendaDTO()
        {

        }

        public AgendaDTO(long idMedico, string horaInicio, string minutoInicio, string horaFim, string minutoFim,
            string diaDaSemana)
        {
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            MinutoInicio = minutoInicio;
            MinutoFim = minutoFim;
            
            DiaDaSemana = diaDaSemana;
        }

        public TimeOnly getHoraInicio()
        {
            return new TimeOnly(int.Parse(this.HoraInicio), int.Parse(this.MinutoInicio));
        }

        public TimeOnly getHoraFim()
        {
            return new TimeOnly(int.Parse(this.HoraFim), int.Parse(this.MinutoFim));
        }
    }
}
