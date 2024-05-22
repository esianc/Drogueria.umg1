using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Presentacion
{
    public string IdPresentacion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
