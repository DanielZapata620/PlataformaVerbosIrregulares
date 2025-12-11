using System;
using System.Collections.Generic;

namespace PlataformaVerbosIrregulares.Models.Entities;

public partial class Verbosirregulares
{
    public int IdVerbo { get; set; }

    public string BaseForm { get; set; } = null!;

    public string Past { get; set; } = null!;

    public string Participle { get; set; } = null!;

    public string Espanol { get; set; } = null!;
}
