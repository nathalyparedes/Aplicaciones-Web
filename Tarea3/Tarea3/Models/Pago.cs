using System;
using System.Collections.Generic;

namespace Tarea3.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int MembresiaId { get; set; }

    public decimal Monto { get; set; }

    public DateOnly FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual Membresia Membresia { get; set; } = null!;
}
