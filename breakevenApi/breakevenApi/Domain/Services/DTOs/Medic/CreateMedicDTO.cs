using System.ComponentModel.DataAnnotations;

namespace breakevenApi.Domain.Services.DTOs.Medic
{
    public class CreateMedicDTO
    {
        public long Crm { get; private set; }
        public double Percentual { get; private set; }
        public string Telefone { get; private set; }
        public string NomeMedico { get; private set; }
        public long CodigoEspecialidade { get; private set; }
    }
}
