using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Inventario
{
    public string IdProducto { get; set; } = null!;

    public string IdBodega { get; set; } = null!;

    public decimal Entradas { get; set; }

    public decimal Salidas { get; set; }

    public decimal Final { get; set; }

    public string IdUbicacion { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;
}
