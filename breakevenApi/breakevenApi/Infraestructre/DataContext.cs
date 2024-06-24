using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Diagnostica;
using breakevenApi.Domain.Entities.Diagnostico;
using breakevenApi.Domain.Entities.Doenca;
using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Entities.ExerceEsp;
using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Entities.Paciente;
using Microsoft.EntityFrameworkCore;

namespace breakevenApi.Infraestructre
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
               
        }

        public DbSet<Medic>? Medics { get; set; }
        public DbSet<Agenda>? Agendas { get; set; }
        public DbSet<Consulta>? Consultas { get; set; }
        public DbSet<Diagnostica>? Diagnostica { get; set; }
        public DbSet<Diagnostico>? Diagnosticos { get; set; }
        public DbSet<Doenca>? Doencas { get; set; }
        public DbSet<Especialidade>? Especialidades { get; set; }
        public DbSet<ExerceEsp>? ExerceEsp { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<HistoricoPaciente>? HistoricosPacientes { get; set; }
    }
}
