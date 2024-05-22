using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Farmacium
{
    public string IdSucursal { get; set; } = null!;

    public string NombreSucursal { get; set; } = null!;

    public string DireccionSucursal { get; set; } = null!;

    public virtual ICollection<Tipodocumento> Tipodocumentos { get; set; } = new List<Tipodocumento>();
}
