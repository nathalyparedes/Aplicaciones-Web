using System;
using System.Collections.Generic;

namespace Tarea3.Models;

public partial class Plan
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int DuracionMeses { get; set; }

    public virtual ICollection<Membresia> Membresia { get; set; } = new List<Membresia>();
}
