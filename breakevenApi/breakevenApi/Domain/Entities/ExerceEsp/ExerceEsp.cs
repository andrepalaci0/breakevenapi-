using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace breakevenApi.Domain.Entities.ExerceEsp
{
    [Table("ExerceEsp")]
    [PrimaryKey(nameof(IdEsp), nameof(IdMedico))]
    public class ExerceEsp
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdEsp { get; private set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdMedico { get; private set; }


        public ExerceEsp(long idEsp, long idMedico)
        {
            IdEsp = idEsp;
            IdMedico = idMedico;
        }
    }
}
