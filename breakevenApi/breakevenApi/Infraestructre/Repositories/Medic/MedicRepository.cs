using breakevenApi.Domain.Entities.Medic;
using Microsoft.EntityFrameworkCore;

namespace breakevenApi.Infraestructre.Repositories;

public class MedicRepository : IMedicRepository
{
    private readonly DataContext _context;

    public MedicRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(Medic medic)
    {
        _context.Medics.Add(medic);
        await _context.SaveChangesAsync();
    }

    public Medic GetByCrm(long crm)
    {
        return _context.Medics.FirstOrDefault(m => m.Crm == crm);
    }

    public async Task<Medic> GetByName(string name)
    {
        return await _context.Medics.FirstOrDefaultAsync(m => m.NomeMedico == name);
    }

    public List<Medic> GetAll()
    {
        return _context.Medics.ToList();
    }


    public List<Medic>? GetByEspecialidade(string nomeEspecialidade)
    {
        var especialidade = _context.Especialidades.FirstOrDefault(e => e.NomeEspecialidade == nomeEspecialidade);
        List<Medic>? medicos = new List<Medic>(); 
        
        var exerceEsp = _context.ExerceEsp.Where(e => e.IdEsp == especialidade.Codigo).ToList();

        foreach (var e in exerceEsp) {

            var medic = _context.Medics.FirstOrDefault(m => m.Crm == e.IdMedico);

            if(medic != null) medicos.Add(medic);
        }
        return medicos;
    }

    public List<Medic>? GetByEspecialidade(long IdEspecialidade)
    {
        var especialidade = _context.Especialidades.FirstOrDefault(e => e.Indice == IdEspecialidade);
        List<Medic>? medicos = new List<Medic>();

        var exerceEsp = _context.ExerceEsp.Where(e => e.IdEsp == especialidade.Codigo).ToList();

        foreach (var e in exerceEsp)
        {

            var medic = _context.Medics.FirstOrDefault(m => m.Crm == e.IdMedico);

            if (medic != null) medicos.Add(medic);
        }
        return medicos;
    }

    public void Update(Medic medic)
    {
        _context.Medics.Update(medic);
        _context.SaveChanges();
    }

    public void Delete(long crm)
    {
        var medic = _context.Medics.FirstOrDefault(m => m.Crm == crm);
        if (medic != null)
        {
            _context.Medics.Remove(medic);
            _context.SaveChanges();
        }
    }
}
