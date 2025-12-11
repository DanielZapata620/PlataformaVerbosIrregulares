using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaVerbosIrregulares.Services;

namespace PlataformaVerbosIrregulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbosController : ControllerBase
    {
        public VerbosController(VerbosService verbosService)
        {
            VerbosService=verbosService;
        }

        public VerbosService VerbosService { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var verbos = VerbosService.GetAllVerbos();
            return Ok(verbos);
        }

        [HttpGet("{cantidad}")]
        public IActionResult GetAll(int cantidad)
        {
            var verbos = VerbosService.GetVerbosByCantidad(cantidad);
            return Ok(verbos);
        }


    }
}
