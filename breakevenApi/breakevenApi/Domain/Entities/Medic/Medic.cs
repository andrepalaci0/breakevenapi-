using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Medic
{
    [Table("Medics")]
    public class Medic
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MedicId { get; private set; }
        public long Crm { get; private set; }

        [Required]
        public double Percentual { get; private set; }

        [Required]
        public string Telefone { get; private set; }

        [Required]
        public string NomeMedico { get; private set; }

        public Medic(long crm, double percentual, string telefone, string nomeMedico)
        {
            Crm = crm;
            Percentual = percentual;
            Telefone = telefone;
            NomeMedico = nomeMedico;
        }
    }
}
