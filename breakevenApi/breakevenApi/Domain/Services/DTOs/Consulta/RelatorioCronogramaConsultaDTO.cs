using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Especialidade;

namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class RelatorioCronogramaConsultaDTO
    {
        public string NomeMedico { get; set; }
        public DateOnly DataConsulta { get; set; }
        public DateTime HoraInicioConsulta { get; set; }

        public string Especialidade { get; set; }

        public string NomePaciente { get; set; }
        public string TelefonePaciente { get; set; }

        public List<HistoricoPaciente> HistoricoPaciente { get; set; }

        public RelatorioCronogramaConsultaDTO(string nomeMedico, DateOnly dataConsulta, DateTime horaInicioConsulta, string especialidade, string nomePaciente, string telefonePaciente, List<HistoricoPaciente> historicoPaciente)
        {
            NomeMedico = nomeMedico;
            DataConsulta = dataConsulta;
            HoraInicioConsulta = horaInicioConsulta;
            Especialidade = especialidade;
            NomePaciente = nomePaciente;
            TelefonePaciente = telefonePaciente;
            HistoricoPaciente = historicoPaciente;
        }
    }
}
