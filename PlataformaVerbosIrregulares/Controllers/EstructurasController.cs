using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaVerbosIrregulares.Services;

namespace PlataformaVerbosIrregulares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstructurasController : ControllerBase
    {
        public EstructurasController(EstructurasGramaticalesService estructurasGramaticalesService)
        {
            EstructurasGramaticalesService=estructurasGramaticalesService;
        }

        public EstructurasGramaticalesService EstructurasGramaticalesService { get; }

        [HttpGet("{tiempo}")]
        public IActionResult Get(string tiempo)
        {
            var estructuras = EstructurasGramaticalesService.GetEstructuraConReglas(tiempo);
            return Ok(estructuras);
        }
    }
}
