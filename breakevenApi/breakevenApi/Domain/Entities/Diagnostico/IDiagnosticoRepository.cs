namespace breakevenApi.Domain.Entities.Diagnostico
{
    public interface IDiagnosticoRepository
    {
        void Create(Diagnostico diagnostico);
        Diagnostico GetById(long diagnosticoId);
        List<Diagnostico> GetAll();
        void Update(Diagnostico diagnostico);
        void Delete(long diagnosticoId);
    }
}
