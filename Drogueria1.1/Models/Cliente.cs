using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Cliente
{
    public string IdCliente { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string IdEnfermedad { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual Enfermedad IdEnfermedadNavigation { get; set; } = null!;
}
