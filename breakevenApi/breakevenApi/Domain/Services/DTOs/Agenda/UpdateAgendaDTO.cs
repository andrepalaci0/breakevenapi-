using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Domain.Services.DTOs.Agenda
{
    public class UpdateAgendaDTO
    {
        public long crm { get; set;} 
        public string dayOfWeek { get; set;}
        public string newHoraInicio { get; set;}
        public string newHoraFim { get; set;}

        public UpdateAgendaDTO(long crm, string dayOfWeek, string newHoraInicio, string newHoraFim)
        {
            this.crm = crm;
            this.dayOfWeek = dayOfWeek;
            this.newHoraInicio = newHoraInicio;
            this.newHoraFim = newHoraFim;
        }
    }
}
