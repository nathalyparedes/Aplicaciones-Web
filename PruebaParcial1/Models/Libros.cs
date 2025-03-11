using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PruebaParcial1.Validations;


namespace PruebaParcial1.Models;

public partial class Libros
{
    public int LibroId { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(50, ErrorMessage = "El título no puede tener más de 50 caracteres.")]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "El género es obligatorio.")]
    [StringLength(50, ErrorMessage = "El género no puede tener más de 50 caracteres.")]
    public string Genero { get; set; } = null!;

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "La fecha de publicación es obligatoria.")]
    [ValidacionFecha(ErrorMessage = "La fecha de publicación debe ser menor que la fecha actual.")]
    public DateOnly? FechaPublicacion { get; set; }

    [Required(ErrorMessage = "El ISBN es obligatorio.")]
    [RegularExpression(@"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$", ErrorMessage = "El ISBN debe tener un formato válido.")]
    public string Isbn { get; set; } = null!;

    public int? AutorId { get; set; }

    public virtual Autores? Autor { get; set; }
}
