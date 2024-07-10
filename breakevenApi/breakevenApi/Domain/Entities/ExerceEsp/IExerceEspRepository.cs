namespace breakevenApi.Domain.Entities.ExerceEsp
{
    public interface IExerceEspRepository
    {
        void Create(ExerceEsp exerceEsp);
        ExerceEsp GetById(long idEsp, long idMedico);
        List<ExerceEsp> GetAll();
        void Update(ExerceEsp exerceEsp);
        void Delete(long idEsp, long idMedico);
    }
}
