using Microsoft.Extensions.Logging.Abstractions;

namespace PlataformaVerbosIrregulares.Models.DTOs
{
    public class VerbosDTO
    {
        public IEnumerable<VerboDTO> ListaVerbos { get; set; } = null!;
       
    }

    public class VerboDTO
    {
        public string Presente { get; set; } = null!;
        public string Pasado { get; set; } = null!;
        public string Participio { get; set; } = null!;
        public string Espanol { get; set; } = null!;
    }
}
