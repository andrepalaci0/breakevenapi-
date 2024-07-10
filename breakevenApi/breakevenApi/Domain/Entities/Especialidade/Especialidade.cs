using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Especialidade
{
    [Table("Especialidades")]
    public class Especialidade
    {
        [Key]
        public long Id { get; private set; }

        [Required]
        public long Codigo { get; private set; }

        [Required]
        public int Indice { get; private set; }

        [Required]
        public string NomeEspecialidade { get; private set; }

        // Constructor to initialize properties
        public Especialidade(long codigo, int indice, string nomeEspecialidade)
        {
            Codigo = codigo;
            Indice = indice;
            NomeEspecialidade = nomeEspecialidade;
        }
    }
}
