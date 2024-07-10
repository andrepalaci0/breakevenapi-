using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Infraestructre;

namespace breakevenApi.Infraestructre.Repositories;

public class AgendaRepository : IAgendaRepository
{
    private readonly DataContext _context;

    public AgendaRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Agenda agenda)
    {
        _context.Agendas.Add(agenda);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        var agenda = _context.Agendas.FirstOrDefault(a => a.Id == id);
        if (agenda != null)
        {
            _context.Agendas.Remove(agenda);
            _context.SaveChanges();
        }
    }

    public List<Agenda> GetAll()
    {
        return _context.Agendas.ToList();
    }

    public Agenda GetById(long id)
    {
        return _context.Agendas.FirstOrDefault(a => a.Id == id);
    }

    public Agenda GetByMedicCrm(long crm)
    {
        return _context.Agendas.FirstOrDefault(a => a.IdMedico == crm);
    }

    public Agenda GetByMedicCrmAndDay(long crm, DayOfWeek day)
    {
        return _context.Agendas.FirstOrDefault(a => a.IdMedico == crm && a.DiaDaSemana == day);
    }

    public void Update(Agenda agenda)
    {
        _context.Agendas.Update(agenda);
        _context.SaveChanges();
    }

}

