namespace breakevenApi.Domain.Entities.Consulta
{
    public interface IConsultaRepository
    {
        Task Create(Consulta consulta);
        Consulta GetById(long idEspecialidade, long idPaciente, long idMedico, DateOnly data);
        List<Consulta> GetAll();
        public List<Consulta> GetAllByIdMedico(long idMedico);
        public List<Consulta> GetByIdPaciente(long idPaciente);

        public List<Consulta> GetAllByDay(DateOnly data);
        void Update(Consulta consulta);
        void Delete(long idEspecialidade, long idPaciente, long idMedico, DateOnly data);
        List<Consulta> GetByCrmAndDate(long idMedico, DateOnly day);
    }
}
