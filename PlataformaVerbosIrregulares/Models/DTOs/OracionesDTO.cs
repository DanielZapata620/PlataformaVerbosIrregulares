namespace PlataformaVerbosIrregulares.Models.DTOs
{
    public class OracionesDTO
    {
        public IEnumerable<OracionDTO> ListaOraciones { get; set; } = null!;

    }    

        public class OracionDTO
        {
            public int id { get; set; }
            public string Descripcion { get; set; } = null!;
            public string VerboBase { get; set; } = null!;
            public string VerboTiempoAdecudado { get; set; } = null!;
         
        }
    
}
