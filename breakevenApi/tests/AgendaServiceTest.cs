
using Moq;
using breakevenApi.Domain.Services.DTOs.Agenda;
using Microsoft.Extensions.Logging;
using System;
using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Services;

namespace breakevenApi.tests
{


    public class AgendaServiceTests
{
    private readonly Mock<IAgendaRepository> _mockAgendaRepository;
    private readonly Mock<IMedicRepository> _mockMedicRepository;
    private readonly Mock<IConsultaRepository> _mockConsultaRepository;
    private readonly Mock<ILogger<AgendaService>> _mockLogger;
    private readonly AgendaService _agendaService;

    
    public AgendaServiceTests()
    {
        _mockAgendaRepository = new Mock<IAgendaRepository>();
        _mockMedicRepository = new Mock<IMedicRepository>();
        _mockConsultaRepository = new Mock<IConsultaRepository>();
        _mockLogger = new Mock<ILogger<AgendaService>>();
        _agendaService = new AgendaService(_mockAgendaRepository.Object, _mockMedicRepository.Object, _mockConsultaRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void CreateAgenda_ValidData_ReturnsTrue()
    {
        long crm = 12345;
        var agendaDto = new AgendaDTO(crm, "08:00", "17:00", "Monday");

        _mockMedicRepository.Setup(repo => repo.GetByCrm(crm)).Returns(new Medic(crm, 0, "Test Phone", "TestName"));

        var result = _agendaService.CreateAgenda(crm, agendaDto);

        Assert.True(result);
        _mockAgendaRepository.Verify(repo => repo.Create(It.IsAny<Agenda>()), Times.Once);
    }

    [Fact]
    public void CreateAgenda_MedicNotFound_ReturnsFalse()
    {
        var crm = 12345;
        var agendaDto = new AgendaDTO (crm, "08:00", "17:00", "Monday");

        _mockMedicRepository.Setup(repo => repo.GetByCrm(crm)).Returns((Medic)null);

        var result = _agendaService.CreateAgenda(crm, agendaDto);

        Assert.False(result);
        _mockAgendaRepository.Verify(repo => repo.Create(It.IsAny<Agenda>()), Times.Never);
    }

    [Fact]
    public void UpdateAgendaByCrmAndDay_ValidData_ReturnsTrue()
    {
        var crm = 12345L;
        var dayOfWeek = "Monday";
        var newHoraInicio = "09:00";
        var newHoraFim = "18:00";
        var existingAgenda = new Agenda(crm, TimeOnly.Parse("08:00"), TimeOnly.Parse("17:00"), DayOfWeek.Monday);

        _mockAgendaRepository.Setup(repo => repo.GetByMedicCrmAndDay(crm, DayOfWeek.Monday)).Returns(existingAgenda);

        var result = _agendaService.UpdateAgendaByCrmAndDay(crm, dayOfWeek, newHoraInicio, newHoraFim);

        Assert.True(result);
        _mockAgendaRepository.Verify(repo => repo.Update(existingAgenda), Times.Once);
    }

    [Fact]
    public void UpdateAgendaByCrmAndDay_AgendaNotFound_ReturnsFalse()
    {
        var crm = 12345L;
        var dayOfWeek = "Monday";
        var newHoraInicio = "09:00";
        var newHoraFim = "18:00";

        _mockAgendaRepository.Setup(repo => repo.GetByMedicCrmAndDay(crm, DayOfWeek.Monday)).Returns((Agenda)null);

        var result = _agendaService.UpdateAgendaByCrmAndDay(crm, dayOfWeek, newHoraInicio, newHoraFim);

        Assert.False(result);
        _mockAgendaRepository.Verify(repo => repo.Update(It.IsAny<Agenda>()), Times.Never);
    }

    [Fact]
    public void ValidateDates_HoraInicioGreaterThanOrEqualHoraFim_ReturnsFalse()
    {
        var horaInicio = TimeOnly.Parse("18:00");
        var horaFim = TimeOnly.Parse("17:00");
        var dayOfWeek = DayOfWeek.Monday;

        var result = _agendaService.ValidateDates(horaInicio, horaFim, dayOfWeek);

        Assert.False(result);
    }

    [Fact]
    public void ValidateDates_InvalidDayOfWeek_ReturnsFalse()
    {
        var horaInicio = TimeOnly.Parse("08:00");
        var horaFim = TimeOnly.Parse("17:00");

        var result = _agendaService.ValidateDates(horaInicio, horaFim, (DayOfWeek)7);

        Assert.False(result);
    }

    [Fact]
    public void ValidateDates_ValidData_ReturnsTrue()
    {
        var horaInicio = TimeOnly.Parse("08:00");
        var horaFim = TimeOnly.Parse("17:00");
        var dayOfWeek = DayOfWeek.Monday;

        var result = _agendaService.ValidateDates(horaInicio, horaFim, dayOfWeek);

        Assert.True(result);
    }
}
}
