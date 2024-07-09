using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Domain.Services;
using breakevenApi.Domain.Services.DTOs.Agenda;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("agenda")]
    public class AgendaController : Controller
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly AgendaService _agendaService;

        public AgendaController(IAgendaRepository agendaRepository, AgendaService agendaService)
        {
            _agendaRepository = agendaRepository;
            _agendaService = agendaService;
        }

        [HttpGet]
        [Route("get-agenda/")]
        public IActionResult GetById([FromQuery] long idAgenda)
        {
            var agenda = _agendaRepository.GetById(idAgenda);
            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }

        [HttpGet]
        [Route("medic/")]
        public IActionResult GetByMedicCrm([FromQuery] long crm)
        {
            var agenda = _agendaRepository.GetByMedicCrm(crm);
            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }

        [HttpPost]
        public IActionResult CreateAgenda(AgendaDTO agenda)
        {
            //agenda deve ser definida como disponibilidae por dia da semana
            //dias da semana devem estar em ingles 
            //ex: segunda 8h as 12h, terça 14h as 18h
            Console.WriteLine("AGENDA: " + agenda);
            DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), agenda.DiaDaSemana);
            var agendaExistente = _agendaRepository.GetByMedicCrmAndDay(agenda.IdMedico, dayOfWeek);
            if (agendaExistente != null)
            {
                return BadRequest("Agenda já cadastrada");
            }
            if (agenda == null)
            {
                return BadRequest();
            }
            if(!_agendaService.CreateAgenda(agenda))
            {
                return BadRequest();
            }
            return Ok("Agenda criada");
        }

        [HttpPatch]
        public IActionResult UpdateAgendaByCrmAndDay([FromBody] UpdateAgendaDTO updateAgendaDTO)
        {
            //atualiza a agenda de um medico em um dia da semana
            //ex: atualiza a agenda do medico de crm 1234 na segunda feira
            if (updateAgendaDTO.crm == 0 || updateAgendaDTO == null)
            {
                return BadRequest();
            }
            if(!_agendaService.UpdateAgendaByCrmAndDay(updateAgendaDTO.crm, updateAgendaDTO.dayOfWeek, updateAgendaDTO.newHoraInicio, updateAgendaDTO.newHoraFim))
            {
                return BadRequest();
            }
            return Ok("Agenda atualizada");
        }
    }
}
