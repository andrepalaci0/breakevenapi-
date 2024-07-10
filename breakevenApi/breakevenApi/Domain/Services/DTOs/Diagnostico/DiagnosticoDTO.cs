namespace breakevenApi.Domain.Services.DTOs.Diagnostico
{
    public class DiagnosticoDTO
    {
        public string Message { get; set; }
        public string RemediosReceitados { get; set; }
        public string TratamentosRecomendados { get; set; }
        public long IdConsulta { get; set; }

        public DiagnosticoDTO(string message, string remediosReceitados, string tratamentosRecomendados, long idConsulta)
        {
            Message = message;
            RemediosReceitados = remediosReceitados;
            TratamentosRecomendados = tratamentosRecomendados;
            IdConsulta = idConsulta;
        }
        
        public DiagnosticoDTO(string message, string remediosReceitados, string tratamentosRecomendados)
        {
            Message = message;
            RemediosReceitados = remediosReceitados;
            TratamentosRecomendados = tratamentosRecomendados;
        }

        public DiagnosticoDTO()
        {
            
        }
    }
}
