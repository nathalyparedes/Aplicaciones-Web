using System;
using System.Collections.Generic;

namespace PruebaParcial1.Models;

public partial class Autores
{
    public int AutorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Nacionalidad { get; set; }

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
