using breakevenApi.Domain.Services.DTOs.Diagnostico;
using Microsoft.VisualBasic.CompilerServices;

namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class FinishesConsultaDTO
    {
        public long IdEsp { get; set; }
        public long IdPaciente { get; set; }
        public long IdMedico { get; set; }
        
        public string HoraInicio { get; set; }
        public string MinutoInicio { get; set; }

        public string HoraFim { get; set; }
        public string MinutoFim { get; set; }
        
        public string DiaConsulta { get; set; }
        public string MesConsulta { get; set; }
        public string AnoConsulta { get; set; }
        public string? FormaPagamento { get; set; }
        public float? ValorPagamento { get; set; }

        public DiagnosticoDTO Diagnostico { get; set; }

        public FinishesConsultaDTO(long idEsp, long idPaciente, long idMedico, string horaInicio, string minutoInicio, string horaFim, string minutoFim, string diaConsulta, string mesConsulta, string anoConsulta, string? formaPagamento, float? valorPagamento, DiagnosticoDTO diagnostico)
        {
            IdEsp = idEsp;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            MinutoInicio = minutoInicio;
            HoraFim = horaFim;
            MinutoFim = minutoFim;
            DiaConsulta = diaConsulta;
            MesConsulta = mesConsulta;
            AnoConsulta = anoConsulta;
            FormaPagamento = formaPagamento;
            ValorPagamento = valorPagamento;
            Diagnostico = diagnostico;
        }

        public FinishesConsultaDTO()
        {
            
        }
        
        public TimeOnly getHoraInicio()
        {
            return new TimeOnly(int.Parse(this.HoraInicio), int.Parse(this.MinutoInicio));
        }

        public TimeOnly getHoraFim()
        {
            return new TimeOnly(int.Parse(this.HoraFim), int.Parse(this.MinutoFim));
        }

        public DateOnly getDataConsulta()
        {
            return new DateOnly(int.Parse(this.AnoConsulta), int.Parse(this.MesConsulta), int.Parse(this.DiaConsulta));
        }
    }
}
