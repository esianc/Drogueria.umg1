using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Enfermedad
{
    public string IdEnfermedad { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
