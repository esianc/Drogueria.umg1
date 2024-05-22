using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Tipodocumento
{
    public string CodigoDoc { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Tipotran { get; set; } = null!;

    public string IdSucursal { get; set; } = null!;

    public string IdBodega { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual Bodega IdBodegaNavigation { get; set; } = null!;

    public virtual Farmacium IdSucursalNavigation { get; set; } = null!;
}
