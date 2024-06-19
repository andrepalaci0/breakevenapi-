using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Doenca
{
    [Table("Doencas")]
    public class Doenca
    {
        [Key]
        public long Id { get; private set; }

        [Required]
        public string Nome { get; private set; }

        // Constructor to initialize properties
        public Doenca(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Doenca(string nome)
        {
            Nome = nome;
        }
    }
}
