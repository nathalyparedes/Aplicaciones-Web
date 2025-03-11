using System;
using System.Collections.Generic;

namespace PruebaParcial1.Models;

public partial class Libros
{
    public int LibroId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateOnly? FechaPublicacion { get; set; }

    public string Isbn { get; set; } = null!;

    public int? AutorId { get; set; }

    public virtual Autores? Autor { get; set; }
}
