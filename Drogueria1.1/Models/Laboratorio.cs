using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Laboratorio
{
    public string IdLaboratorio { get; set; } = null!;

    public string NombreLab { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
