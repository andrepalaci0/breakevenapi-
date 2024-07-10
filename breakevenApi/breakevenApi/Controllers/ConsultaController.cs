using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Services;
using breakevenApi.Domain.Services.DTOs.Consulta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace breakevenApi.Controllers
{

    [Route("consulta")]
    public class ConsultaController : Controller
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly ConsultaService _consultaService;

        public ConsultaController(IConsultaRepository consultaRepository, ConsultaService consultaService)
        {
            _consultaRepository = consultaRepository;
            _consultaService = consultaService;
        }

        [HttpGet]
        [Route("getByMedic")]
        public IActionResult getConsultasByMedicCrm([FromQuery]long id)
        {
            var consulta = _consultaRepository.GetAllByIdMedico(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpGet]
        [Route("getByMedicName")]
        public IActionResult getConsultaByMedicName(string name)
        {
            var consulta = _consultaService.GetByMedicName(name);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpGet]
        [Route("cronogram")]
        public IActionResult GetCrongorama()
        {
            DateOnly data = DateOnly.FromDateTime(DateTime.Now);
            var cronogram= _consultaService.GetDayCronogram(data);
            if (cronogram == null)
            {
                return NotFound("Não há cronograma pra hoje.");
            }
            return Ok(cronogram);
        }

        [HttpGet]
        [Route("horariolivre")]
        public IActionResult GetHorarioLivre([FromQuery] long IdMedico, [FromQuery] DateOnly Data)
        {
            //DateOnly formatteddata = DateOnly.Parse(horarioLivreDTO.Data);
            
            var horario = _consultaService.GetHorariosLivres(Data, IdMedico);
            if (horario == null)
            {
                return NotFound("Não há horários livres com esse médico nesse dia.");
            }
            return Ok(horario);
        }



        [HttpGet]
        [Route("getByPaciente")]
        public IActionResult getConsultaByPacienteId([FromQuery]long id)
        {
            var consulta = _consultaRepository.GetByIdPaciente(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpGet]
        [Route("get/")]
        public IActionResult getConsulta([FromQuery] long IdEspecialidade, [FromQuery] long IdPaciente, [FromQuery] long IdMedico, [FromQuery] DateOnly data)
        {
            var consulta = _consultaRepository.GetById(IdEspecialidade, IdPaciente, IdMedico, data);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpPost]
        [Route("agenda-consulta")]
        public IActionResult CreateConsulta(CreateConsultaDTO createConsultaDTO)
        {
            /*
            if (createConsultaDTO.NomeMedicoPreferencia.IsNullOrEmpty())
            {
                var possibleMedics = _consultaService.GetMedicsByEspecialidade(createConsultaDTO.CodigoEspecialidade);
                return BadRequest("É necessário definir o médico que realizará a consulta. Escolha os médicos disponíveis na lista: " + possibleMedics);
            }
            */

            if (!_consultaService.InitialCadastroPaciente(createConsultaDTO)) return BadRequest("Erro ao cadastrar paciente");
      
            if (!_consultaService.CreateConsulta(createConsultaDTO).Result) return BadRequest("Erro ao criar consulta");

            return Ok();
        }

        [HttpPatch]
        [Route("finaliza")] 
        public IActionResult FinishesConsulta(FinishesConsultaDTO finishesConsultaDTO)
        {
            try{
                
            var consulta = _consultaService.FinishesConsulta(finishesConsultaDTO);   
            
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Consulta Finalizada");
        }

    }
}
