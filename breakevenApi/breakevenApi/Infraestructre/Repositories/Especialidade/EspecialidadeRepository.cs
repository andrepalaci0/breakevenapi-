using breakevenApi.Domain.Entities.Especialidade;

namespace breakevenApi.Infraestructre.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly DataContext _context;

        public EspecialidadeRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Especialidade especialidade)
        {
            if (especialidade == null)
            {
                throw new ArgumentNullException(nameof(especialidade));
            }

            _context.Especialidades.Add(especialidade);
            await _context.SaveChangesAsync();
        }

        public Especialidade GetByCodigo(long codigo)
        {
            return _context.Especialidades.FirstOrDefault(e => e.Codigo == codigo);
        }

        public List<Especialidade> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        public void Update(Especialidade especialidade)
        {
            if (especialidade == null)
            {
                throw new ArgumentNullException(nameof(especialidade));
            }

            _context.Especialidades.Update(especialidade);
            _context.SaveChanges();
        }

        public void Delete(long codigo)
        {
            var especialidade = _context.Especialidades.FirstOrDefault(e => e.Codigo == codigo);
            if (especialidade != null)
            {
                _context.Especialidades.Remove(especialidade);
                _context.SaveChanges();
            }
        }
    }
}
