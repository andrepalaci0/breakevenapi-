using System.Collections.Generic;
using System.Threading.Tasks;

namespace breakevenApi.Domain.Entities.Medic
{
    public interface IMedicRepository
    {
        Task Create(Medic medic);
        Medic? GetByCrm(long crm);
        Medic? GetByName(string name);
        List<Medic>? GetAll();
        List<Medic>? GetByEspecialidade(long IdEspecialidade);
        List<Medic>? GetByEspecialidade(string nomeEspecialidade);
        void Update(Medic medic);
        void Delete(long crm);
    }
}
