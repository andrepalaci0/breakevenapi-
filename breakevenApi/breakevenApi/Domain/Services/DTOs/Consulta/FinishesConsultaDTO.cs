using breakevenApi.Domain.Services.DTOs.Diagnostico;

namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class FinishesConsultaDTO
    {
        public long IdEsp { get; set; }
        public long IdPaciente { get; set; }
        public long IdMedico { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly? HoraFimConsulta { get; set; }
        public string? FormaPagamento { get; set; }
        public float? ValorPagamento { get; set; }

        public DiagnosticoDTO Diagnostico { get; set; }

        public FinishesConsultaDTO(long idEsp, long idPaciente, long idMedico, DateOnly data, TimeOnly? horaFimConsulta, string? formaPagamento, float? valorPagamento, DiagnosticoDTO diagnostico)
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
