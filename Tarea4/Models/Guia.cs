using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{   
    public class Guia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del guía es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido del guía es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La experiencia del guía es obligatoria.")]
        [Range(1, 50, ErrorMessage = "La experiencia debe ser entre 1 y 50 años.")]
        public int ExperienciaAnios { get; set; }

        // Relación con Visitas
        public List<Visita> Visitas { get; set; } = new();
    }
}
