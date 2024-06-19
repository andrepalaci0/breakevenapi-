using breakevenApi.Domain.Entities.Agenda;
using breakevenApi.Domain.Services;
using breakevenApi.Domain.Services.DTOs.Agenda;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/agenda")]
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
        [Route("/get-agenda/{idAgenda}")]
        public IActionResult GetById(long idAgenda)
        {
            var agenda = _agendaRepository.GetById(idAgenda);
            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }

        [HttpGet]
        [Route("/medico/{crm}")]
        public IActionResult GetByMedicCrm(long crm)
        {
            var agenda = _agendaRepository.GetByMedicCrm(crm);
            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }

        [HttpPut]
        [Route("/{crm}")]
        public IActionResult CreateAgenda(long crm, [FromBody] AgendaDTO agenda)
        {
            //agenda deve ser definida como disponibilidae por dia da semana
            //ex: segunda 8h as 12h, terça 14h as 18h
            if (agenda == null)
            {
                return BadRequest();
            }
            if(!_agendaService.CreateAgenda(crm, agenda))
            {
                return BadRequest();
            }
            return Ok("Agenda criada");
        }

        [HttpPatch]
        [Route("/{crm}")]
        public IActionResult UpdateAgendaByCrmAndDay([FromQuery] long crm, [FromBody] string dayOfWeek, [FromBody] string newHoraInicio, [FromBody] string newHoraFim)
        {
            //atualiza a agenda de um medico em um dia da semana
            //ex: atualiza a agenda do medico de crm 1234 na segunda feira
            if (crm == 0 || dayOfWeek == null)
            {
                return BadRequest();
            }
            if(!_agendaService.UpdateAgendaByCrmAndDay(crm, dayOfWeek, newHoraInicio, newHoraFim))
            {
                return BadRequest();
            }
            return Ok("Agenda atualizada");
        }
    }
}
