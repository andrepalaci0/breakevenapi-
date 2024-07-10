using breakevenApi.Domain.Entities.Diagnostico;

namespace breakevenApi.Infraestructre.Repositories
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly DataContext _context;

        public DiagnosticoRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Diagnostico diagnostico)
        {
            if (diagnostico == null)
            {
                throw new ArgumentNullException(nameof(diagnostico));
            }

            _context.Diagnosticos.Add(diagnostico);
            _context.SaveChanges();
        }

        public Diagnostico GetById(long diagnosticoId)
        {
            return _context.Diagnosticos.FirstOrDefault(d => d.DiagnosticoId == diagnosticoId);
        }

        public List<Diagnostico> GetAll()
        {
            return _context.Diagnosticos.ToList();
        }

        public void Update(Diagnostico diagnostico)
        {
            if (diagnostico == null)
            {
                throw new ArgumentNullException(nameof(diagnostico));
            }

            _context.Diagnosticos.Update(diagnostico);
            _context.SaveChanges();
        }

        public void Delete(long diagnosticoId)
        {
            var diagnostico = _context.Diagnosticos.FirstOrDefault(d => d.DiagnosticoId == diagnosticoId);
            if (diagnostico != null)
            {
                _context.Diagnosticos.Remove(diagnostico);
                _context.SaveChanges();
            }
        }
    }
}
