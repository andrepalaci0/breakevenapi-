using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Entities.ExerceEsp;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/especialidade")]
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
        [Route("/get/{idEspecialidade}")]
        public IActionResult GetEspecialidadeById(long idEspecialidade)
        {
            return Ok(_especialidadeRepository.GetByCodigo(idEspecialidade));
        }

        [HttpPost]
        public IActionResult CreateEspecialidade([FromBody] Especialidade especialidade)
        {
            try{
                _especialidadeRepository.Create(especialidade);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("/exerce")]
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
