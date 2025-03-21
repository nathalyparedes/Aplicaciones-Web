using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del animal es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La especie es obligatoria.")]
        [StringLength(50, ErrorMessage = "La especie no puede superar los 50 caracteres.")]
        public string Especie { get; set; } = null!;

        [Required(ErrorMessage = "El hábitat es obligatorio.")]
        public int HabitatId { get; set; }

        [Required(ErrorMessage = "La dieta es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dieta no puede superar los 100 caracteres.")]
        public string Dieta { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateOnly FechaIngreso { get; set; }

        // Relación con Hábitat
        public Habitat? Habitat { get; set; }
    }
}
