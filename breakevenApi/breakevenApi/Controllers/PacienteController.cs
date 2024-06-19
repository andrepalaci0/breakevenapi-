using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Services;
using breakevenApi.Domain.Services.DTOs.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{

    [Route("/paciente")]
    public class PacienteController : Controller 
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ConsultaService _consultaService;

        public PacienteController(IPacienteRepository pacienteRepository, ConsultaService consultaService)
        {
            _pacienteRepository = pacienteRepository;
            _consultaService = consultaService;
        }

        [HttpGet]
        [Route("/get/{idPaciente}")]
        public IActionResult GetPacienteById(long idPaciente)
        {
            return Ok(_pacienteRepository.GetByCodigo(idPaciente));
        }

        [HttpPut]
        [Route("/adds-missing-data/")]
        public IActionResult FinishesCadastroPaciente([FromBody] FinishesCadastroPacienteDTO pacienteDTO)
        {
            try
            {
                _consultaService.FinishesCadastroPaciente(pacienteDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
