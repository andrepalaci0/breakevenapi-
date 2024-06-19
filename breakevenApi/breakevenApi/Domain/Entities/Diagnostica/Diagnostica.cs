using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Diagnostica
{
    [Table("Diagnostica")]
    [PrimaryKey(nameof(IdDiagnostico), nameof(IdDoenca))]
    public class Diagnostica
    {
        

        [Required]
        [ForeignKey(nameof(IdDiagnostico))]
        public long IdDiagnostico { get; private set; }

        [Required]
        [ForeignKey(nameof(IdDoenca))]
        public long IdDoenca { get; private set; }

        public Diagnostica(long idDiagnostico, long idDoenca)
        {
            IdDiagnostico = idDiagnostico;
            IdDoenca = idDoenca;
        }

    }
}
