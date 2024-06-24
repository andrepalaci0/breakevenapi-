using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace breakevenApi.Domain.Entities.ExerceEsp
{
    [Table("ExerceEsp")]
    public class ExerceEsp
    {
        [Key]
        public long Id { get; private set; }
        public long IdEsp { get; private set; }

        public long IdMedico { get; private set; }


        public ExerceEsp(long idEsp, long idMedico)
        {
            IdEsp = idEsp;
            IdMedico = idMedico;
        }
    }
}
