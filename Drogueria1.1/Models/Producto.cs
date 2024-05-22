using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Producto
{
    public string IdProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string IdIngredientea { get; set; } = null!;

    public string IdPresentacion { get; set; } = null!;

    public double Costo { get; set; }

    public double PrecioPublico { get; set; }

    public double PrecioMayorista { get; set; }

    public string IdLaboratorio { get; set; } = null!;

    public virtual ICollection<Detalledocumento> Detalledocumentos { get; set; } = new List<Detalledocumento>();

    public virtual Ingrediente IdIngredienteaNavigation { get; set; } = null!;

    public virtual Laboratorio IdLaboratorioNavigation { get; set; } = null!;

    public virtual Presentacion IdPresentacionNavigation { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
