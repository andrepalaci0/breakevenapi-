namespace breakevenApi.Domain.Entities.Diagnostica
{
    public interface IDiagnosticaRepository
    {
        void Create(Diagnostica diagnostica);
        Diagnostica GetById(long idDiagnostico, long idDoenca);
        List<Diagnostica> GetAll();
        void Update(Diagnostica diagnostica);
        void Delete(long idDiagnostico, long idDoenca);
    }
}
