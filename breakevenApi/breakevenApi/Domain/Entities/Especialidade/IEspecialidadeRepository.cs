namespace breakevenApi.Domain.Entities.Especialidade
{
    public interface IEspecialidadeRepository
    {
        Task Create(Especialidade especialidade);
        Especialidade GetByCodigo(long codigo);
        List<Especialidade> GetAll();
        void Update(Especialidade especialidade);
        void Delete(long codigo);
    }
}
