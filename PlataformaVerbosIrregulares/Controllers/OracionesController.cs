using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaVerbosIrregulares.Services;

namespace PlataformaVerbosIrregulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OracionesController : ControllerBase
    {
        public OracionesController(OracionesService oracionesService)
        {
            OracionesService=oracionesService;
        }

        public OracionesService OracionesService { get; }


        [HttpGet("{cantidad}")]
        public IActionResult GetAll(int cantidad)
        {
            var oraciones = OracionesService.GetOracionesByCantidad(cantidad);
            return Ok(oraciones);
        }
    }
}
