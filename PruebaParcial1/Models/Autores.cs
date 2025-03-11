using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PruebaParcial1.Validations;


namespace PruebaParcial1.Models;

public partial class Autores
{
    public int AutorId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
    public string Apellido { get; set; } = null!;

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [ValidacionFecha(ErrorMessage = "La fecha de nacimiento debe ser menor que la fecha actual.")]
    public DateOnly? FechaNacimiento { get; set; }

    [Required(ErrorMessage = "La nacionalidad es obligatoria.")]

    [StringLength(50, ErrorMessage = "La nacionalidad no puede tener más de 50 caracteres.")]
    public string? Nacionalidad { get; set; }

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
