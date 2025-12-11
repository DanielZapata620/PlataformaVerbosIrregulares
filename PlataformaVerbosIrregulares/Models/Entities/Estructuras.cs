using System;
using System.Collections.Generic;

namespace PlataformaVerbosIrregulares.Models.Entities;

public partial class Estructuras
{
    public int IdEstructura { get; set; }

    public string? Tiempo { get; set; }

    public string? Tipo { get; set; }

    public string? Modo { get; set; }

    public string? Sujeto { get; set; }

    public string? Auxiliar { get; set; }

    public string? Verbo { get; set; }

    public string? Complemento { get; set; }

    public virtual ICollection<Reglas> Reglas { get; set; } = new List<Reglas>();
}
