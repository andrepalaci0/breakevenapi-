using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Services.DTOs.Agenda;

namespace breakevenApi.Domain.Services
{
    public class AgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMedicRepository _medicRepository;
        private readonly IConsultaRepository _consultaRepository;
        private readonly ILogger<AgendaService> _logger;

        public AgendaService(IAgendaRepository agendaRepository, IMedicRepository medicRepository, IConsultaRepository consultaRepository, ILogger<AgendaService> logger)
        {
            _agendaRepository = agendaRepository;
            _medicRepository = medicRepository;
            _consultaRepository = consultaRepository;
            _logger = logger;
        }

        public bool CreateAgenda(long crm, AgendaDTO agenda)
        {
            var medic = _medicRepository.GetByCrm(crm);
            if (medic == null)
            {
                _logger.LogError("Medic not found");
                return false;
            }
            try
            {
                TimeOnly horaInicio = TimeOnly.Parse(agenda.HoraInicio);
                TimeOnly horaFim = TimeOnly.Parse(agenda.HoraFim);
                DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), agenda.DiaDaSemana);

                if (!ValidateDates(horaInicio, horaFim, dayOfWeek)) return false;

                var newAgenda = new Agenda(crm, horaInicio, horaFim, dayOfWeek);
                _agendaRepository.Create(newAgenda);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return true;
        }

        public bool UpdateAgendaByCrmAndDay(long crm, string dayOfWeek, string newHoraInicio, string newHoraFim)
        {
            try
            {
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek);
                TimeOnly horaInicio = TimeOnly.Parse(newHoraInicio);
                TimeOnly horaFim = TimeOnly.Parse(newHoraFim);
                var agenda = _agendaRepository.GetByMedicCrmAndDay(crm, day);
                if (agenda == null)
                {
                    _logger.LogError("Agenda not found");
                    return false;
                }

                if (!ValidateDates(horaInicio, horaFim, day)) return false;

                agenda.HoraInicio = horaInicio;
                agenda.HoraFim = horaFim;
                _agendaRepository.Update(agenda);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return true;
        }

        public bool ValidateDates(TimeOnly horaInicio, TimeOnly horaFim, DayOfWeek dia)
        {
            if (horaInicio >= horaFim)
            {
                _logger.LogError("Hora de inicio não pode ser maior ou igual a hora de fim");
                return false;
            }
            if (dia < DayOfWeek.Sunday || dia > DayOfWeek.Saturday)
            {
                _logger.LogError("Dia da semana inválido");
                return false;
            }
            return true;
        }
    }
}
