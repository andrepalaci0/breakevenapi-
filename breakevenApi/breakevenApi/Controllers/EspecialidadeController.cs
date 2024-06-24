using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Entities.ExerceEsp;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("especialidade")]
    public class EspecialidadeController : Controller
    {

        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IExerceEspRepository _exerceEspRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IExerceEspRepository exerceEspRepository)
        {
            _especialidadeRepository = especialidadeRepository;
            _exerceEspRepository = exerceEspRepository;
        }



        [HttpGet]
        [Route("get-by-code/{idEspecialidade}")]
        public IActionResult GetEspecialidadeById(long idEspecialidade)
        {
            var especialidade = _especialidadeRepository.GetByCodigo(idEspecialidade);
            if(especialidade == null)
            {
                return NotFound();
            }
            return Ok(especialidade);
        }

        [HttpPost]
        public IActionResult CreateEspecialidade([FromBody] Especialidade especialidade)
        {
            var especialidadeExistente = _especialidadeRepository.GetByCodigo(especialidade.Codigo);

            if(especialidadeExistente != null) return BadRequest("Especialidade já cadastrada");

            try{
                _especialidadeRepository.Create(especialidade);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("exerce")]
        public IActionResult CreateExerceEsp([FromBody] ExerceEsp exerceEsp)
        {
            try{
                _exerceEspRepository.Create(exerceEsp);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
