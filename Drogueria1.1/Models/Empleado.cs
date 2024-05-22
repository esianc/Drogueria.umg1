using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Empleado
{
    public string IdEmpleado { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
