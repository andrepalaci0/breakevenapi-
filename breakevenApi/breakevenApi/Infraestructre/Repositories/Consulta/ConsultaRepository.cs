using breakevenApi.Domain.Entities.Consulta;

namespace breakevenApi.Infraestructre.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly DataContext _context;

        public ConsultaRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Consulta consulta)
        {
            if (consulta == null)
            {
                throw new ArgumentNullException(nameof(consulta));
            }

            _context.Consultas.Add(consulta);
            _context.SaveChanges();
        }


        public Consulta GetById(long idEspecialidade, long idPaciente, long idMedico, DateOnly data)
        {
            return _context.Consultas.FirstOrDefault(c => c.IdEspecialidade == idEspecialidade && c.IdPaciente == idPaciente && c.IdMedico == idMedico && c.Data == data);
        }

        public List<Consulta> GetAll()
        {
            return _context.Consultas.ToList();
        }

        public List<Consulta> GetAllByDay(DateOnly data)
        {
               return _context.Consultas.Where(c => c.Data == data).ToList();
        }
        public List<Consulta> GetAllByIdMedico(long idMedico)
        {
            {
                return _context.Consultas.Where(c => c.IdMedico == idMedico).ToList();
            }
        }

        public List<Consulta> GetByIdPaciente(long idPaciente)
        {
            return _context.Consultas
                           .Where(c => c.IdPaciente == idPaciente)
                           .ToList();
        }

        public void Update(Consulta consulta)
        {
            if (consulta == null)
            {
                throw new ArgumentNullException(nameof(consulta));
            }

            _context.Consultas.Update(consulta);
            _context.SaveChanges();
        }

        public List<Consulta> GetByCrmAndDate(long idMedico, DateOnly data)
        {
            return _context.Consultas.Where(c => c.IdMedico == idMedico && c.Data == data).ToList();
        }

        public void Delete(long idEspecialidade, long idPaciente, long idMedico, DateOnly data)
        {
            var consulta = _context.Consultas.FirstOrDefault(c => c.IdEspecialidade == idEspecialidade && c.IdPaciente == idPaciente && c.IdMedico == idMedico && c.Data == data);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                _context.SaveChanges();
            }
        }
    }
}
