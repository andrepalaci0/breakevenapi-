using breakevenApi.Domain.Entities.Especialidade;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/especialidade")]
    public class EspecialidadeController : Controller
    {

        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
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
    }
}
