using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Agenda
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        [Required]
        public long Id { get; private set; }

        [Required]
        public long IdMedico { get; private set; }

        [Required]
        public TimeOnly HoraInicio { get; set; }

        [Required]
        public TimeOnly HoraFim { get; set; }


        [Required]
        public DayOfWeek DiaDaSemana { get; set; }

        // Constructor to initialize properties
        public Agenda(long idMedico, TimeOnly horaInicio, TimeOnly horaFim, DayOfWeek diaDaSemana)
        {
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            DiaDaSemana = diaDaSemana;
        }
    }
}
