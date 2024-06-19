
using breakevenApi.Domain.Entities.ExerceEsp;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Services.DTOs.Medic;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Controllers
{
    [Route("/medic")]
    public class MedicController : Controller
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IExerceEspRepository _exerceEspRepository;


        public MedicController(IMedicRepository medicRepository, IExerceEspRepository exerceEspRepository)
        {
            _medicRepository = medicRepository;
            _exerceEspRepository = exerceEspRepository;
        }

        [HttpGet]
        [Route("/get/{idMedico}")]
        public IActionResult getMedicById(long idMedico)
        {
            var medic = _medicRepository.GetByCrm(idMedico);
            if (medic == null )
            {
                return NotFound(); 
            }

            return Ok(medic); 
        }

        [HttpPost]
        public IActionResult CreateMedic([FromBody] CreateMedicDTO createMedicDTO)
        {
            var medic = new Medic(createMedicDTO.Crm, createMedicDTO.Percentual, createMedicDTO.Telefone, createMedicDTO.NomeMedico); 
            try
            {
                _medicRepository.Create(medic);
                _exerceEspRepository.Create(new ExerceEsp(medic.Crm, createMedicDTO.CodigoEspecialidade));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
