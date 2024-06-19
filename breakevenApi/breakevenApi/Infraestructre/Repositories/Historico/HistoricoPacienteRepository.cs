using breakevenApi.Domain.Entities.Historico;

namespace breakevenApi.Infraestructre.Repositories.Historico
{
    public class HistoricoPacienteRepository : IHistoricoPacienteRepository
    {
        private readonly DataContext _context;

        public HistoricoPacienteRepository(DataContext context)
        {
            _context = context;
        }



        public void Add(HistoricoPaciente historicoPaciente)
        {
            _context.HistoricosPacientes.Add(historicoPaciente);
            _context.SaveChanges();
        }

        public void Update(HistoricoPaciente historicoPaciente)
        {
            _context.HistoricosPacientes.Update(historicoPaciente);
            _context.SaveChanges();
        }

        public void Delete(long idPaciente, long idConsulta)
        {
            var historicoPaciente = _context.HistoricosPacientes.FirstOrDefault(h => h.IdPaciente == idPaciente && h.IdConsulta == idConsulta);
            if (historicoPaciente != null)
            {
                _context.HistoricosPacientes.Remove(historicoPaciente);
                _context.SaveChanges();
            }
        }

        public List<HistoricoPaciente> GetByPaciente(long idPaciente)
        {
            var list = _context.HistoricosPacientes.Where(h => h.IdPaciente == idPaciente).ToList();
            return list;
        }

        public HistoricoPaciente GetById(long idPaciente, long idConsulta)
        {
            return _context.HistoricosPacientes.FirstOrDefault(h => h.IdPaciente == idPaciente && h.IdConsulta == idConsulta);
        }
    }
}

