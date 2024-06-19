namespace breakevenApi.Domain.Services.DTOs.Paciente
{
    public class FinishesCadastroPacienteDTO
    {
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public string CPFPaciente { get; set; }

        public FinishesCadastroPacienteDTO(string CPFpaciente, string sexo, string endereco, DateTime dataNascimento)
        {
            Sexo = sexo;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            CPFPaciente = CPFpaciente;
        }
    }
}
