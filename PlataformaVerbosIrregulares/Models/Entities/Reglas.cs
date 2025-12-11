using System;
using System.Collections.Generic;

namespace PlataformaVerbosIrregulares.Models.Entities;

public partial class Reglas
{
    public int IdRegla { get; set; }

    public string? Descripcion { get; set; }

    public string? CambioEn { get; set; }

    public int? IdEstructura { get; set; }

    public virtual Estructuras? IdEstructuraNavigation { get; set; }
}
