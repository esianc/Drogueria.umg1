using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Documento
{
    public string CodigoDoc { get; set; } = null!;

    public decimal NumeroDoc { get; set; }

    public string IdCliente { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Seriefac { get; set; } = null!;

    public decimal Numerofac { get; set; }

    public string IdBodega { get; set; } = null!;

    public decimal Totaldoc { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public string IdEmpleado { get; set; } = null!;

    public decimal Iva { get; set; }

    public virtual Tipodocumento CodigoDocNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
