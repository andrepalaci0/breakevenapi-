
using breakevenApi.Domain.Entities.Paciente;

namespace breakevenApi.Infraestructre.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;

    public PacienteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
    }

    public Paciente GetByCodigo(long codigoPaciente)
    {
        return _context.Pacientes.FirstOrDefault(p => p.CodigoPaciente == codigoPaciente);
    }

    public Paciente GetByCpf(string cpf)
    {
        return _context.Pacientes.FirstOrDefault(p => p.Cpf == cpf);
    }
    public List<Paciente> GetAll()
    {
        return _context.Pacientes.ToList();
    }

    public void Update(Paciente paciente)
    {
        _context.Pacientes.Update(paciente);
        _context.SaveChanges();
    }

    public void Delete(long codigoPaciente)
    {
        var paciente = _context.Pacientes.FirstOrDefault(p => p.CodigoPaciente == codigoPaciente);
        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }
    }
}
