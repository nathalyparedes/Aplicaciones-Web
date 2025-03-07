using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tarea3.Models;

public partial class Membresia
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int PlanId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaExpiracion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Plan Plan { get; set; } = null!;
}
