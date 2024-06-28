namespace breakevenApi.Domain.Entities.Historico
{
    public interface IHistoricoPacienteRepository
    {
        public List<HistoricoPaciente> GetByPaciente(long idPaciente);

        public HistoricoPaciente GetById(long idPaciente, long idConsulta);
        public void Add(HistoricoPaciente historicoPaciente);
        public void Update(HistoricoPaciente historicoPaciente);
        public void Delete(long idPaciente, long idConsulta);
    }
}
