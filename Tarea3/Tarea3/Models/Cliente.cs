using System;
using System.Collections.Generic;

namespace Tarea3.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Teléfono { get; set; } = null!;

    public string? Dirección { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public virtual ICollection<Membresia> Membresia { get; set; } = new List<Membresia>();
}
