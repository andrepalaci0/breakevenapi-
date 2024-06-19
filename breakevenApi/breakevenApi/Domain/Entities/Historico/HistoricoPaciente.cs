using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Historico
{
    [Table("HistoricosPacientes")]
    [PrimaryKey(nameof(IdPaciente), nameof(IdConsulta))]
    public class HistoricoPaciente
    {
        public long IdPaciente { get; set; }

        public long IdConsulta { get; set; }

        public string Doenca { get; set; }

        public DateOnly DataConsulta { get; set; }

        public string NomeMedico { get; set; }

        public HistoricoPaciente(long idPaciente, long idConsulta, string doenca, DateOnly dataConsulta, string nomeMedico)
        {
            IdPaciente = idPaciente;
            IdConsulta = idConsulta;
            Doenca = doenca;
            DataConsulta = dataConsulta;
            NomeMedico = nomeMedico;
        }
    }
}
