using breakevenApi.Domain.Entities.Doenca;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("doenca")]
    public class DoencaController : Controller
    {
        private readonly IDoencaRepository _doencaRepository;

        public DoencaController(IDoencaRepository doencaRepository)
        {
            _doencaRepository = doencaRepository;
        }


        [HttpGet]
        [Route("get/")]
        public IActionResult GetDoencaById([FromQuery] long idDoenca)
        {
            try
            {
                var doenca = _doencaRepository.GetById(idDoenca);
                if (doenca == null) return NotFound("Doenca nao encontrada");
                return Ok(doenca);
            
            }
            catch(Exception e)
            {

               return BadRequest(e.Message);
            }        
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAllDoencas()
        {
            try
            {
                return Ok(_doencaRepository.GetAll());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateDoenca([FromBody] string NomeDoenca)
        {
            try
            {
                _doencaRepository.Create(new Doenca(NomeDoenca));
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("delete/")]
        public IActionResult DeleteDoenca([FromQuery] long id)
        {
            try
            {
                _doencaRepository.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
