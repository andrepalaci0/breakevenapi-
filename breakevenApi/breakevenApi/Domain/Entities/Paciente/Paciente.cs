using breakevenApi.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Paciente
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public long CodigoPaciente { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomePaciente { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get;   set; }

        public Sexo Sexo { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        public DateTime DataNascimento { get;  set; }

        public int Idade { get; set; }

        // Constructor to initialize properties
        public Paciente(long codigoPaciente, string cpf, string nomePaciente, string telefone, Sexo sexo, string endereco, DateTime dataNascimento)
        {
            CodigoPaciente = codigoPaciente;
            Cpf = cpf;
            NomePaciente = nomePaciente;
            Telefone = telefone;
            Sexo = sexo;
            Endereco = endereco;
            DataNascimento = dataNascimento;
        }

        public Paciente(string cpf, string nomePaciente, string telefone, Sexo sexo, string endereco, DateTime datanascimento)
        {
            Cpf = cpf;
            NomePaciente = nomePaciente;
            Telefone = telefone;
            Sexo = sexo;
            Endereco = endereco;
            DataNascimento = datanascimento;
            Idade = this.GetIdade();
        }

        public Paciente(string nomePaciente, string telefonePaciente, string cpfPaciente) { 
            NomePaciente = nomePaciente;
            Telefone = telefonePaciente;
            Cpf = cpfPaciente;
            Endereco = "vazio";
            Sexo = Sexo.INDEFINIDO;
            DataNascimento = DateTime.Now;
        }   

        private int GetIdade()
        {
            DateTime today = DateTime.Today;
            Idade = today.Year - DataNascimento.Year;

            if (DataNascimento.Date > today.AddYears(-Idade)) Idade--;

            return Idade;
        }
    }
}
