using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Diagnostica;
using breakevenApi.Domain.Entities.Diagnostico;
using breakevenApi.Domain.Entities.Doenca;
using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Entities.ExerceEsp;
using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Services;
using breakevenApi.Infraestructre;
using breakevenApi.Infraestructre.Repositories;
using breakevenApi.Infraestructre.Repositories.Historico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connectionString),
        ServiceLifetime.Singleton);



builder.Services.AddSingleton<IAgendaRepository, AgendaRepository>();
builder.Services.AddSingleton<IConsultaRepository, ConsultaRepository>();
builder.Services.AddSingleton<IDiagnosticaRepository, DiagnosticaRepository>();
builder.Services.AddSingleton<IDiagnosticoRepository, DiagnosticoRepository>();
builder.Services.AddSingleton<IDoencaRepository, DoencaRepository>();
builder.Services.AddSingleton<IEspecialidadeRepository, EspecialidadeRepository>();
builder.Services.AddSingleton<IExerceEspRepository, ExerceEspRepository>();
builder.Services.AddSingleton<IMedicRepository, MedicRepository>();
builder.Services.AddSingleton<IPacienteRepository, PacienteRepository>();
builder.Services.AddSingleton<IHistoricoPacienteRepository, HistoricoPacienteRepository>();
builder.Services.AddSingleton<ConsultaService>();
builder.Services.AddSingleton<AgendaService>();


var app = builder.Build();
app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
