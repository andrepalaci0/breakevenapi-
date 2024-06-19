using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Diagnostico
{
    [Table("Diagnosticos")]
    public class Diagnostico
    {
        [Key]
        public long DiagnosticoId { get; private set; }

        [Required]
        public string Message { get; private set; }

        [Required]
        public string RemediosReceitados { get; private set; }

        [Required]
        public string TratamentosRecomendados { get; private set; }

        [Required]
        public long IdConsulta { get; private set; }

        // Constructor to initialize properties
        public Diagnostico(string message, string remediosReceitados, string tratamentosRecomendados, long idConsulta)
        {
            Message = message;
            RemediosReceitados = remediosReceitados;
            TratamentosRecomendados = tratamentosRecomendados;
            IdConsulta = idConsulta;
        }
    }
}
