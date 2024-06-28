using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Services.DTOs.Consulta;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using breakevenApi.Domain.Services.DTOs.Diagnostico;
using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Diagnostico;
using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Entities.Enums;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Services;
using breakevenApi.Domain.Services.DTOs.Paciente;
using breakevenApi.Domain.Entities.ExerceEsp;
using breakevenApi.Domain.Entities.Diagnostica;

namespace breakevenApi.Services.Tests
{
    public class ConsultaServiceTests
    {
        private readonly Mock<IConsultaRepository> _mockConsultaRepository;
        private readonly Mock<IMedicRepository> _mockMedicRepository;
        private readonly Mock<IDiagnosticoRepository> _mockDiagnosticoRepository;
        private readonly Mock<IDiagnosticaRepository> _mockDiagnosticaRepository;
        private readonly Mock<IHistoricoPacienteRepository> _mockHistoricoPacienteRepository;
        private readonly Mock<IPacienteRepository> _mockPacienteRepository;
        private readonly Mock<IEspecialidadeRepository> _mockEspecialidadeRepository;
        private readonly Mock<IExerceEspRepository> _mockExerceEspRepository;
        private readonly Mock<ILogger<ConsultaService>> _mockLogger;
        private readonly ConsultaService _consultaService;

        public ConsultaServiceTests()
        {
            _mockConsultaRepository = new Mock<IConsultaRepository>();
            _mockMedicRepository = new Mock<IMedicRepository>();
            _mockDiagnosticoRepository = new Mock<IDiagnosticoRepository>();
            _mockDiagnosticaRepository = new Mock<IDiagnosticaRepository>();
            _mockHistoricoPacienteRepository = new Mock<IHistoricoPacienteRepository>();
            _mockPacienteRepository = new Mock<IPacienteRepository>();
            _mockEspecialidadeRepository = new Mock<IEspecialidadeRepository>();
            _mockExerceEspRepository = new Mock<IExerceEspRepository>();
            _mockLogger = new Mock<ILogger<ConsultaService>>();
            
            _consultaService = new ConsultaService(
                _mockConsultaRepository.Object,
                _mockMedicRepository.Object,
                _mockDiagnosticoRepository.Object,
                _mockDiagnosticaRepository.Object,
                _mockHistoricoPacienteRepository.Object,
                _mockPacienteRepository.Object,
                _mockEspecialidadeRepository.Object,
                _mockExerceEspRepository.Object,
                _mockLogger.Object);
        }

        [Fact]
        public void GetByMedicName_MedicExists_ReturnsConsultas()
        {
            var medic = new Medic(123L, 1, "Phone", "Dr. House");
            var consultas = new List<Consulta> { new Consulta(1L, 2L, 123L, DateOnly.Parse("2023-01-01"), DateTime.Now, DateTime.Now.AddMinutes(30), true, MetodosPagamento.PIX, 100) };

            _mockMedicRepository.Setup(repo => repo.GetByName("Dr. House")).Returns(medic);
            _mockConsultaRepository.Setup(repo => repo.GetAllByIdMedico(123L)).Returns(consultas);

            var result = _consultaService.GetByMedicName("Dr. House");

            Assert.Equal(consultas, result);
        }

        [Fact]
        public void GetByMedicName_MedicNotExists_ReturnsNull()
        {
            _mockMedicRepository.Setup(repo => repo.GetByName("Dr. Strange")).Returns((Medic)null);

            var result = _consultaService.GetByMedicName("Dr. Strange");

            Assert.Null(result);
        }

        
        [Fact]
        public void FinishesConsulta_ValidData_ReturnsTrue()
        {
            var diagnosticoDTO = new DiagnosticoDTO(
                "Healthy",
                "None",
                "Rest",
                0
            );

            var finishesConsultaDTO = new FinishesConsultaDTO(
                1L,
                2L,
                3L,
                "2023-01-01",
                "14:30",
                "PIX",
                100,
                diagnosticoDTO
            );

            var consulta = new Consulta(
                1L,
                2L,
                3L,
                DateOnly.Parse("2023-01-01"),
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                MetodosPagamento.PIX,
                0
            );

            var diagnostico = new Diagnostico(
                "Healthy",
                "None",
                "Rest",
                0
            );

            _mockConsultaRepository.Setup(repo => repo.GetById(1L, 2L, 3L, DateOnly.Parse("2023-01-01"))).Returns(consulta);
            _mockDiagnosticoRepository.Setup(repo => repo.Create(It.IsAny<Diagnostico>())).Verifiable();
            _mockDiagnosticoRepository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(diagnostico);
            _mockMedicRepository.Setup(repo => repo.GetByCrm(It.IsAny<long>())).Returns(new Medic(3L, 1, "1234567890", "Dr. House"));
            _mockConsultaRepository.Setup(repo => repo.Update(consulta)).Verifiable();
            _mockHistoricoPacienteRepository.Setup(repo => repo.GetById(It.IsAny<long>(), It.IsAny<long>())).Returns((HistoricoPaciente)null);
            _mockHistoricoPacienteRepository.Setup(repo => repo.Add(It.IsAny<HistoricoPaciente>())).Verifiable();

            var result = _consultaService.FinishesConsulta(finishesConsultaDTO);

            Assert.True(result);
            _mockConsultaRepository.Verify(repo => repo.Update(consulta), Times.Once);
            _mockDiagnosticoRepository.Verify(repo => repo.Create(It.IsAny<Diagnostico>()), Times.Once);
            _mockHistoricoPacienteRepository.Verify(repo => repo.Add(It.IsAny<HistoricoPaciente>()), Times.Once);
        }

        [Fact]
        public void GetDayCronogram_ConsultasExist_ReturnsCronogram()
        {
            // Arrange
            var day = DateOnly.Parse("2023-01-01");
            var consultas = new List<Consulta>
            {
               new Consulta(1L, 2L, 3L, day, DateTime.Now, DateTime.Now.AddMinutes(30), true, MetodosPagamento.PIX, 100)
            };

            _mockConsultaRepository.Setup(repo => repo.GetAllByDay(day)).Returns(consultas);
            _mockMedicRepository.Setup(repo => repo.GetByCrm(3L)).Returns(new Medic(3L, 1,"1234567890", "Dr. House"));
            _mockEspecialidadeRepository.Setup(repo => repo.GetByCodigo(1L)).Returns(new Especialidade(1L, 1, "Cardiology"));
            _mockPacienteRepository.Setup(repo => repo.GetByCodigo(2L)).Returns(new Paciente(2L, "12345678901", "John Doe", "123-456-7890", Sexo.MASCULINO, "123 Main St", DateTime.Parse("1990-01-01")));
            _mockHistoricoPacienteRepository.Setup(repo => repo.GetByPaciente(2L)).Returns(new List<HistoricoPaciente>());

            // Act
            var result = _consultaService.GetDayCronogram(day);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            /*
            var cronogram = result.First();
            Assert.Equal("Dr. House", cronogram.NomeMedico);
            Assert.Equal(day, cronogram.DataConsulta);
            Assert.Equal(consultas[0].HoraInicioConsulta, cronogram.HoraInicioConsulta);
            Assert.Equal("Cardiology", cronogram.Especialidade);
            Assert.Equal("John Doe", cronogram.NomePaciente);
            Assert.Equal("123-456-7890", cronogram.TelefonePaciente);
            */
        }


        [Fact]
        public void GetHorariosLivres_NoConsultas_ReturnsAllHorariosAsLivres()
        {
            var day = DateOnly.Parse("2023-01-01");
            var idMedico = 123L;

            _mockConsultaRepository.Setup(repo => repo.GetByCrmAndDate(idMedico, day)).Returns((List<Consulta>)null);

            var result = _consultaService.GetHorariosLivres(day, idMedico);

            Assert.All(result, horario => Assert.True(horario.Livre));
        }

        [Fact]
        public void GetHorariosLivres_WithConsultas_ReturnsCorrectHorariosLivres()
        {
            var day = DateOnly.Parse("2023-01-01");
            var idMedico = 123L;
            var consultas = new List<Consulta>
            {
                new Consulta(1L, 2L, idMedico, day, new DateTime(day.Year, day.Month, day.Day, 9, 0, 0), new DateTime(day.Year, day.Month, day.Day, 9, 30, 0), true, MetodosPagamento.PIX, 100)
            };

            _mockConsultaRepository.Setup(repo => repo.GetByCrmAndDate(idMedico, day)).Returns(consultas);

            var result = _consultaService.GetHorariosLivres(day, idMedico);

            Assert.False(result.First(h => h.HoraInicio == new DateTime(day.Year, day.Month, day.Day, 9, 0, 0)).Livre);
            Assert.True(result.First(h => h.HoraInicio == new DateTime(day.Year, day.Month, day.Day, 8, 0, 0)).Livre);
        }
        [Fact]
        public void CreateConsulta_ValidData_ReturnsTrue()
        {
            var createConsultaDTO = new CreateConsultaDTO
            (
                 "John Doe",
                 "123-456-7890",
                 "12345678901",
                 1L,
                DateOnly.Parse("2023-01-01"),
                new DateTime(2023, 1, 1, 9, 0, 0),
                new DateTime(2023, 1, 1, 9, 30, 0),
                "Dr. House"
            );

            var medic = new Medic(3L, 1, "1234567890", "Dr. House");

            _mockMedicRepository.Setup(repo => repo.GetByName("Dr. House")).Returns(medic);
            _mockConsultaRepository.Setup(repo => repo.GetByCrmAndDate(medic.Crm, createConsultaDTO.DataConsulta)).Returns(new List<Consulta>());
            _mockEspecialidadeRepository.Setup(repo => repo.GetByCodigo(createConsultaDTO.CodigoEspecialidade)).Returns(new Especialidade(1L, 1, "Cardiology"));
            _mockPacienteRepository.Setup(repo => repo.GetByCpf(createConsultaDTO.CPFPaciente)).Returns(new Paciente("12345678901", "John Doe", "123-456-7890"));

            var result = _consultaService.CreateConsulta(createConsultaDTO);

            Assert.True(result);
        }

        [Fact]
        public void CreateConsulta_TimeSlotNotAvailable_ReturnsFalse()
        {
            var createConsultaDTO = new CreateConsultaDTO
            (
                 "John Doe",
                 "123-456-7890",
                 "12345678901",
                 1L,
                DateOnly.Parse("2023-01-01"),
                new DateTime(2023, 1, 1, 9, 0, 0),
                new DateTime(2023, 1, 1, 9, 30, 0),
                "Dr. House"
            );


            var medic = new Medic(3L, 1, "1234567890", "Dr. House");

            var overlappingConsulta = new Consulta(1L, 2L, 3L, createConsultaDTO.DataConsulta, createConsultaDTO.HoraInicio, createConsultaDTO.HoraFim, true, MetodosPagamento.PIX, 100);

            _mockMedicRepository.Setup(repo => repo.GetByName("Dr. House")).Returns(medic);
            _mockConsultaRepository.Setup(repo => repo.GetByCrmAndDate(medic.Crm, createConsultaDTO.DataConsulta)).Returns(new List<Consulta> { overlappingConsulta });

            var result = _consultaService.CreateConsulta(createConsultaDTO);

            Assert.False(result);
        }

        [Fact]
        public void InitialCadastroPaciente_NewPaciente_ReturnsTrue()
        {
            var createConsultaDTO = new CreateConsultaDTO
            (
                 "John Doe",
                 "123-456-7890",
                 "12345678901",
                 1L,
                DateOnly.Parse("2023-01-01"),
                new DateTime(2023, 1, 1, 9, 0, 0),
                new DateTime(2023, 1, 1, 9, 30, 0),
                "Dr. House"
            );

            _mockPacienteRepository.Setup(repo => repo.GetByCpf(createConsultaDTO.CPFPaciente)).Returns((Paciente)null);
            _mockPacienteRepository.Setup(repo => repo.Create(It.IsAny<Paciente>())).Verifiable();

            var result = _consultaService.InitialCadastroPaciente(createConsultaDTO);

            Assert.True(result);
            _mockPacienteRepository.Verify(repo => repo.Create(It.IsAny<Paciente>()), Times.Once);
        }

        [Fact]
        public void InitialCadastroPaciente_ExistingPaciente_ReturnsTrue()
        {
            var createConsultaDTO = new CreateConsultaDTO
            (
                 "John Doe",
                 "123-456-7890",
                 "12345678901",
                 1L,
                DateOnly.Parse("2023-01-01"),
                new DateTime(2023, 1, 1, 9, 0, 0),
                new DateTime(2023, 1, 1, 9, 30, 0),
                "Dr. House"
            );


            var existingPaciente = new Paciente("12345678901", "John Doe", "123-456-7890");

            _mockPacienteRepository.Setup(repo => repo.GetByCpf(createConsultaDTO.CPFPaciente)).Returns(existingPaciente);

            var result = _consultaService.InitialCadastroPaciente(createConsultaDTO);

            Assert.True(result);
        }

        [Fact]
        public void FinishesCadastroPaciente_PacienteNotFound_ReturnsFalse()
        {
            var finishesCadastroPacienteDTO = new FinishesCadastroPacienteDTO
            (
                "123124124",
                "MASCULINO",
                "Endereco",
                DateTime.Parse("1990-01-01")
            );

            _mockPacienteRepository.Setup(repo => repo.GetByCpf(finishesCadastroPacienteDTO.CPFPaciente)).Returns((Paciente)null);

            var result = _consultaService.FinishesCadastroPaciente(finishesCadastroPacienteDTO);

            Assert.False(result);
        }

        [Fact]
        public void FinishesCadastroPaciente_ValidData_ReturnsTrue()
        {
            var finishesCadastroPacienteDTO = new FinishesCadastroPacienteDTO
            (
                "123124124",
                "MASCULINO",
                "Endereco",
                DateTime.Parse("1990-01-01")
            );

            var existingPaciente = new Paciente("12345678901", "John Doe", "123-456-7890");

            _mockPacienteRepository.Setup(repo => repo.GetByCpf(finishesCadastroPacienteDTO.CPFPaciente)).Returns(existingPaciente);
            _mockPacienteRepository.Setup(repo => repo.Update(existingPaciente)).Verifiable();

            var result = _consultaService.FinishesCadastroPaciente(finishesCadastroPacienteDTO);

            Assert.True(result);
            _mockPacienteRepository.Verify(repo => repo.Update(existingPaciente), Times.Once);
        }

    }
}
