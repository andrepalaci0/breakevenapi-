using breakevenApi.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Entities.Consulta
{
    [Table("Consultas")]
    [PrimaryKey(nameof(IdEspecialidade), nameof(IdPaciente), nameof(IdMedico), nameof(Data))]
    public class Consulta
    {
        public long IdEspecialidade { get;  set; }
        public long IdPaciente { get;  set; }
        public long IdMedico { get; set; }
        public DateOnly Data { get; set; }

        public long IdDiagnostico { get; set; }

        [Required]
        public TimeOnly HoraInicioConsulta { get; set; }

        public TimeOnly HoraFimConsulta { get; set; }

        public bool Paga { get; set; }

        public MetodosPagamento? FormaPagamento { get; set; }

        public float? ValorPagamento { get; set; }

        // Constructor to initialize properties

        public Consulta() { }
        public Consulta(long idEspecialidade, long idPaciente, long idMedico, DateOnly data, TimeOnly horaInicioConsulta, TimeOnly horaFimConsulta, bool paga, MetodosPagamento? formaPagamento, float? valorPagamento)
        {
            IdEspecialidade = idEspecialidade;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            Data = data;
            HoraInicioConsulta = horaInicioConsulta;
            HoraFimConsulta = horaFimConsulta;
            Paga = paga;
            FormaPagamento = formaPagamento;
            ValorPagamento = valorPagamento;
        }

        public long GetId()
        {
            return long.Parse($"{IdEspecialidade}{IdPaciente}{IdMedico}{Data.Day}");
        }
    }
}
