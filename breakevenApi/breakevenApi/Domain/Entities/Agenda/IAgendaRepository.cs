using System.Collections.Generic;
using System.Threading.Tasks;

namespace breakevenApi.Domain.Entities.Agenda
{
    public interface IAgendaRepository
    {
        Task Create(Agenda agenda);
        Agenda GetById(long id);
        List<Agenda> GetAll();
        void Update(Agenda agenda);
        void Delete(long id);
        Agenda GetByMedicCrm(long crm);
        Agenda GetByMedicCrmAndDay(long crm, DayOfWeek day);
    }
}