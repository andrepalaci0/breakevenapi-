using breakevenApi.Domain.Entities.Doenca;

namespace breakevenApi.Infraestructre.Repositories
{
    public class DoencaRepository : IDoencaRepository
    {
        private readonly DataContext _context;

        public DoencaRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Doenca doenca)
        {
            if (doenca == null) 
            {
                throw new ArgumentNullException(nameof(doenca));
            }

            _context.Doencas.Add(doenca);
            await _context.SaveChangesAsync();
        }

        public Doenca GetById(long id)
        {
            return _context.Doencas.FirstOrDefault(d => d.Id == id);
        }

        public List<Doenca> GetAll()
        {
            return _context.Doencas.ToList();
        }

        public void Update(Doenca doenca)
        {
            if (doenca == null)
            {
                throw new ArgumentNullException(nameof(doenca));
            }

            _context.Doencas.Update(doenca);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var doenca = _context.Doencas.FirstOrDefault(d => d.Id == id);
            if (doenca != null)
            {
                _context.Doencas.Remove(doenca);
                _context.SaveChanges();
            }
        }
    }
}
