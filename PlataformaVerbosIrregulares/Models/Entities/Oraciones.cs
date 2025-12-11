using System;
using System.Collections.Generic;

namespace PlataformaVerbosIrregulares.Models.Entities;

public partial class Oraciones
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string VerboBase { get; set; } = null!;

    public string VerboCorrecto { get; set; } = null!;
}
