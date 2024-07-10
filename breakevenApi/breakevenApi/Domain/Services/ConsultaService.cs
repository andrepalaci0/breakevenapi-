using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Diagnostica;
using breakevenApi.Domain.Entities.Diagnostico;
using breakevenApi.Domain.Entities.Enums;
using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Entities.ExerceEsp;
using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Services.DTOs.Paciente;
using breakevenApi.Domain.Services.DTOs.Consulta;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace breakevenApi.Domain.Services
{
    public class ConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMedicRepository _medicoRepository;
        private readonly IDiagnosticoRepository _diagnosticoRepository;
        private readonly IDiagnosticaRepository _diagnosticaRepository;
        private readonly IHistoricoPacienteRepository _historicoPacienteRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IExerceEspRepository _exerceEspRepository;
        private readonly ILogger<ConsultaService> _logger;

        public ConsultaService(IConsultaRepository consultaRepository,
            IMedicRepository medicRepository,
            IDiagnosticoRepository diagnosticoRepository,
            IDiagnosticaRepository diagnosticaRepository,
            IHistoricoPacienteRepository historicoPacienteRepository,
            IPacienteRepository pacienteRepository,
            IEspecialidadeRepository especialidadeRepository,
            IExerceEspRepository exerceEspRepository,
            ILogger<ConsultaService> logger)
        {
            _consultaRepository = consultaRepository;
            _medicoRepository = medicRepository;
            _diagnosticoRepository = diagnosticoRepository;
            _historicoPacienteRepository = historicoPacienteRepository;
            _pacienteRepository = pacienteRepository;
            _especialidadeRepository = especialidadeRepository;
            _exerceEspRepository = exerceEspRepository;
            _diagnosticaRepository = diagnosticaRepository;
            _logger = logger;
        }

        public List<Consulta> GetByMedicName(string name)
        {

            var medic = _medicoRepository.GetByName(name).Result;
            if (medic == null)
            {
                return null;
            }
            return _consultaRepository.GetAllByIdMedico(medic.Crm);
        }

        public bool FinishesConsulta(FinishesConsultaDTO finishesConsultaDTO)
        {
            DateOnly formatteddata = finishesConsultaDTO.Data;

            var consulta = _consultaRepository.GetById(finishesConsultaDTO.IdEsp, finishesConsultaDTO.IdPaciente, finishesConsultaDTO.IdMedico, formatteddata);
            
            if (consulta == null)
            {
                _logger.LogError("Consulta não encontrada");
                return false;
            }
            consulta.HoraFimConsulta = (TimeOnly) finishesConsultaDTO.HoraFimConsulta;

            var diagnostico = finishesConsultaDTO.Diagnostico;
            Diagnostico newDiagnostico = new Diagnostico(
                diagnostico.Message,
                diagnostico.RemediosReceitados,
                diagnostico.TratamentosRecomendados,
                consulta.GetId()
                );

            consulta.IdDiagnostico = newDiagnostico.DiagnosticoId;

            consulta.Paga = false;
            consulta.FormaPagamento = null;
            consulta.ValorPagamento = null;

            if (!finishesConsultaDTO.FormaPagamento.IsNullOrEmpty()){
                consulta.Paga = true;
                consulta.FormaPagamento = (MetodosPagamento)Enum.Parse(typeof(MetodosPagamento), finishesConsultaDTO.FormaPagamento);
                consulta.ValorPagamento = finishesConsultaDTO.ValorPagamento;
            }

            try{
                _diagnosticoRepository.Create(newDiagnostico);
                _consultaRepository.Update(consulta);
                _diagnosticaRepository.Create(new Diagnostica(newDiagnostico.DiagnosticoId, finishesConsultaDTO.IdPaciente));
            }
            catch (Exception e){
                _logger.LogError(e.Message);
                return false;
            }
            AddHistorico(consulta);
            return true;
        }

        public bool InitialCadastroPaciente(CreateConsultaDTO createConsultaDTO)
        {
            var paciente = _pacienteRepository.GetByCpf(createConsultaDTO.CPFPaciente);
            if(paciente == null)
            {
                paciente = new Paciente(createConsultaDTO.NomePaciente, createConsultaDTO.TelefonePaciente, createConsultaDTO.CPFPaciente);
                try
                {
                    _pacienteRepository.Create(paciente);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return false;
                }
            }
            return true;
        }

        public bool FinishesCadastroPaciente(FinishesCadastroPacienteDTO finishesCadastroPacienteDTO)
        {
            var paciente = _pacienteRepository.GetByCpf(finishesCadastroPacienteDTO.CPFPaciente);
            if (paciente == null)
            {
                _logger.LogError("Paciente não encontrado");
                return false;
            }
            paciente.Endereco = finishesCadastroPacienteDTO.Endereco;
            paciente.DataNascimento = finishesCadastroPacienteDTO.DataNascimento; 
            paciente.Sexo = (Sexo)Enum.Parse(typeof(Sexo), finishesCadastroPacienteDTO.Sexo);
            try
            {
                _pacienteRepository.Update(paciente);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }


        //accept both string (especialidade name) and ID
        public List<Medic>? GetMedicsByEspecialidade(string especialidade)
        {
            return _medicoRepository.GetByEspecialidade(especialidade);
        }

        public List<Medic>? GetMedicsByEspecialidade(long IdEspecialidae)
        {
            return _medicoRepository.GetByEspecialidade(IdEspecialidae);
        }

        public List<RelatorioCronogramaConsultaDTO> GetDayCronogram(DateOnly day)
        {
            var todayConsults = _consultaRepository.GetAllByDay(day);

            if (todayConsults == null)
            {
                _logger.LogError("Nenhuma consulta encontrada para o dia");
                return null;
            }
            List<RelatorioCronogramaConsultaDTO> todayCronogram = new List<RelatorioCronogramaConsultaDTO>();
            foreach (var consult in todayConsults)
            {
                var cronogram = new RelatorioCronogramaConsultaDTO(
                    _medicoRepository.GetByCrm(consult.IdMedico).NomeMedico,
                    consult.Data,
                    consult.HoraInicioConsulta,
                    _especialidadeRepository.GetByCodigo(consult.IdEspecialidade).ToString(),
                    _pacienteRepository.GetByCodigo(consult.IdPaciente).NomePaciente,
                    _pacienteRepository.GetByCodigo(consult.IdPaciente).Telefone,
                    _historicoPacienteRepository.GetByPaciente(consult.IdPaciente)
                    );
                todayCronogram.Add(cronogram);
            }
            return todayCronogram;
        }

        public List<HorarioDTO> GetHorariosLivres(DateOnly day, long idMedico)
        {
            var consultas = _consultaRepository.GetByCrmAndDate(idMedico, day);
            var horarios = GenerateHorarios(day);
            if (consultas == null)
                return horarios;

            foreach (var consulta in consultas)
            {
                foreach (var horario in horarios)
                {

                    if (IsOverlapping(consulta.HoraInicioConsulta, consulta.HoraFimConsulta, horario.HoraInicio, horario.HoraFim))
                    {
                        horario.Livre = false;
                    }
                }
            }
            return horarios;
        }


        public bool AddHistorico(Consulta consulta)
        {
            var historico = _historicoPacienteRepository.GetById(consulta.IdPaciente, consulta.GetId());
            if (historico == null)
            {
                HistoricoPaciente newHistorico = new HistoricoPaciente(consulta.IdPaciente, consulta.GetId(),
                    _diagnosticoRepository.GetById(consulta.IdDiagnostico).Message,
                    consulta.Data,
                    _medicoRepository.GetByCrm(consulta.IdMedico).NomeMedico);

                try
                {
                    _historicoPacienteRepository.Add(newHistorico);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return false;
                }
                return true;
            }
            _logger.LogError("Historico já existe");
            return false;
        }

        public List<HorarioDTO> GenerateHorarios(DateOnly date)
        {
            var horarios = new List<HorarioDTO>();
            var startTime = new TimeOnly(8, 0);
            var endTime = new TimeOnly(17, 00);
            
            while (startTime.CompareTo(endTime) < 0)
            {
                var fim = startTime.AddMinutes(30); // 30 minutes
                horarios.Add(new HorarioDTO(startTime, fim, true));
                startTime = fim;
            }

            return horarios;
        }

        private bool IsOverlapping(TimeOnly consultaStart, TimeOnly consultaEnd, TimeOnly slotStart, TimeOnly slotEnd)
        {
            return consultaStart.CompareTo(slotEnd) < 0 && consultaEnd.CompareTo(slotStart) > 0;
        }


        public async Task<bool> CreateConsulta(CreateConsultaDTO createConsultaDTO)
        {
            var medic = await _medicoRepository.GetByName(createConsultaDTO.NomeMedicoPreferencia);
            if (!IsTimeSlotAvailable(createConsultaDTO.HoraInicio, createConsultaDTO.HoraFim, medic.Crm, createConsultaDTO.DataConsulta))
            {
                return false; 
            }
            var newConsulta = new Consulta(
                _especialidadeRepository.GetByCodigo(createConsultaDTO.CodigoEspecialidade).Codigo,
                _pacienteRepository.GetByCpf(createConsultaDTO.CPFPaciente).CodigoPaciente,
                medic.Crm,
                new DateOnly(createConsultaDTO.DataConsulta.Year, createConsultaDTO.DataConsulta.Month, createConsultaDTO.DataConsulta.Day),
                createConsultaDTO.HoraInicio,
                createConsultaDTO.HoraFim,
                false,
                null,
                null
                );
            _consultaRepository.Create(newConsulta);
            return true;
        }

        public bool IsTimeSlotAvailable(TimeOnly startTime, TimeOnly endTime, long crm, DateOnly day)
        {
            var dayConsultas = _consultaRepository.GetByCrmAndDate(crm, day);
            foreach (var consulta in dayConsultas)
            {
                if (startTime.CompareTo(consulta.HoraFimConsulta) < 0 && endTime.CompareTo(consulta.HoraInicioConsulta) > 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
