using breakevenApi.Domain.Entities.Diagnostica;
using breakevenApi.Infraestructre;

namespace breakevenApi.Infraestructre.Repositories
{
    public class DiagnosticaRepository : IDiagnosticaRepository
    {
        private readonly DataContext _context;

        public DiagnosticaRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Diagnostica diagnostica)
        {
            if (diagnostica == null)
            {
                throw new ArgumentNullException(nameof(diagnostica));
            }

            _context.Diagnostica.Add(diagnostica);
            await _context.SaveChangesAsync();
        }

        public Diagnostica GetById(long idDiagnostico, long idDoenca)
        {
            return _context.Diagnostica.FirstOrDefault(d => d.IdDiagnostico == idDiagnostico && d.IdDoenca == idDoenca);
        }

        public List<Diagnostica> GetAll()
        {
            return _context.Diagnostica.ToList();
        }

        public void Update(Diagnostica diagnostica)
        {
            if (diagnostica == null)
            {
                throw new ArgumentNullException(nameof(diagnostica));
            }

            _context.Diagnostica.Update(diagnostica);
            _context.SaveChanges();
        }

        public void Delete(long idDiagnostico, long idDoenca)
        {
            var diagnostica = _context.Diagnostica.FirstOrDefault(d => d.IdDiagnostico == idDiagnostico && d.IdDoenca == idDoenca);
            if (diagnostica != null)
            {
                _context.Diagnostica.Remove(diagnostica);
                _context.SaveChanges();
            }
        }
    }
}
