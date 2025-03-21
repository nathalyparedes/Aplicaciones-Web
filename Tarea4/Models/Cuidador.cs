using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{
    public class Cuidador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cuidador es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido del cuidador es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; } = null!;

        // Relación con Hábitats (Muchos a Muchos)
        public List<CuidadorHabitat> CuidadoresHabitats { get; set; } = new();
    }
}
