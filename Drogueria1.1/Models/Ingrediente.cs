using System;
using System.Collections.Generic;

namespace Drogueria1._1_.Models;

public partial class Ingrediente
{
    public string IdIngredientea { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
