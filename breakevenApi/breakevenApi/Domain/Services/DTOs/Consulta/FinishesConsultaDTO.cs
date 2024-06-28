using breakevenApi.Domain.Services.DTOs.Diagnostico;

namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class FinishesConsultaDTO
    {
        public long IdEsp { get; set; }
        public long IdPaciente { get; set; }
        public long IdMedico { get; set; }
        public string Data { get; set; }
        public string? HoraFimConsulta { get; set; }
        public string? FormaPagamento { get; set; }
        public float? ValorPagamento { get; set; }

        public DiagnosticoDTO Diagnostico { get; set; }

        public FinishesConsultaDTO(long idEsp, long idPaciente, long idMedico, string data, string? horaFimConsulta, string? formaPagamento, float? valorPagamento, DiagnosticoDTO diagnostico)
        {
            IdEsp = idEsp;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            Data = data;
            HoraFimConsulta = horaFimConsulta;
            FormaPagamento = formaPagamento;
            ValorPagamento = valorPagamento;
            Diagnostico = diagnostico;
        }
    }
}
