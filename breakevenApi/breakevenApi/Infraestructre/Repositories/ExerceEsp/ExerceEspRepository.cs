using breakevenApi.Domain.Entities.ExerceEsp;

namespace breakevenApi.Infraestructre.Repositories
{
    public class ExerceEspRepository : IExerceEspRepository
    {
        private readonly DataContext _context;

        public ExerceEspRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(ExerceEsp exerceEsp)
        {
            _context.ExerceEsp.Add(exerceEsp);
            _context.SaveChanges();
        }

        public ExerceEsp GetById(long idEsp, long idMedico)
        {
            return _context.ExerceEsp.FirstOrDefault(e => e.IdEsp == idEsp && e.IdMedico == idMedico);
        }

        public List<ExerceEsp> GetAll()
        {
            return _context.ExerceEsp.ToList();
        }

        public void Update(ExerceEsp exerceEsp)
        {
            _context.ExerceEsp.Update(exerceEsp);
            _context.SaveChanges();
        }

        public void Delete(long idEsp, long idMedico)
        {
            var exerceEsp = _context.ExerceEsp.FirstOrDefault(e => e.IdEsp == idEsp && e.IdMedico == idMedico);
            if (exerceEsp != null)
            {
                _context.ExerceEsp.Remove(exerceEsp);
                _context.SaveChanges();
            }
        }
    }
}
