namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class CreateConsultaDTO
    {
        public string NomePaciente { get; set; }

        public string TelefonePaciente { get; set; }

        public string CPFPaciente { get; set; }

        public long CodigoEspecialidade { get; set; }
        

        public string HoraInicio { get; set; }
        public string MinutoInicio { get; set; }

        public string HoraFim { get; set; }
        public string MinutoFim { get; set; }
        
        public string DiaConsulta { get; set; }
        public string MesConsulta { get; set; }
        public string AnoConsulta { get; set; }
        public string? NomeMedicoPreferencia { get; set; }


        public CreateConsultaDTO(string nomePaciente, string telefonePaciente, string cpfPaciente, long codigoEspecialidade, string horaInicio, string minutoInicio, string horaFim, string minutoFim, string diaConsulta, string mesConsulta, string anoConsulta, string? nomeMedicoPreferencia)
        {
            NomePaciente = nomePaciente;
            TelefonePaciente = telefonePaciente;
            CPFPaciente = cpfPaciente;
            CodigoEspecialidade = codigoEspecialidade;
            HoraInicio = horaInicio;
            MinutoInicio = minutoInicio;
            HoraFim = horaFim;
            MinutoFim = minutoFim;
            DiaConsulta = diaConsulta;
            MesConsulta = mesConsulta;
            AnoConsulta = anoConsulta;
            NomeMedicoPreferencia = nomeMedicoPreferencia;
        }

        public CreateConsultaDTO()
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
