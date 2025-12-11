namespace PlataformaVerbosIrregulares.Models.DTOs
{
    public class EstructurasDTO
    {
        public IEnumerable<EstructuraDTO> Estructuras { get; set; } = null!;

        public IEnumerable<ReglaDTO> Reglas { get; set; } = null!;
    }
    public class EstructuraDTO
    {
        public string Tiempo { get; set; } = null!;       
        public string Tipo { get; set; } = null!;
        public string Modo { get; set; } = null!;
        public string Sujeto { get; set; } = null!;
        public string Auxiliar { get; set; } = null!;
        public string Verbo { get; set; } = null!;
        public string Complemento { get; set; } = null!;
    }
    public class ReglaDTO
    {  
        public string Descripcion { get; set; } = null!;
        public string CambioEn { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Modo { get; set; } = null!;


        
    }
}
