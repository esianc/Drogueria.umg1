using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Ubicacion
{
    public string IdUbicacion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
