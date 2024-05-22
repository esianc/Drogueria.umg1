using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Bodega
{
    public string IdBodega { get; set; } = null!;

    public string NombreBod { get; set; } = null!;

    public string DirBodega { get; set; } = null!;

    public virtual ICollection<Tipodocumento> Tipodocumentos { get; set; } = new List<Tipodocumento>();
}
