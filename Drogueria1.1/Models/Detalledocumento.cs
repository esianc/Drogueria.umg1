using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Detalledocumento
{
    public string CodigoDoc { get; set; } = null!;

    public decimal NumeroDoc { get; set; }

    public string IdProducto { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal Costo { get; set; }

    public decimal Descuento { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
