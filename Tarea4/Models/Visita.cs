using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{   
    public class Visita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de la visita es obligatoria.")]
        public DateOnly FechaVisita { get; set; }

        [Required(ErrorMessage = "La hora de la visita es obligatoria.")]
        public TimeOnly HoraVisita { get; set; }

        [Required(ErrorMessage = "La cantidad de personas es obligatoria.")]
        [Range(1, 100, ErrorMessage = "La cantidad de personas debe estar entre 1 y 100.")]
        public int CantidadPersonas { get; set; }

        [Required(ErrorMessage = "El ID del guía es obligatorio.")]
        public int GuiaId { get; set; }

        // Relación con Guía
        public Guia? Guia { get; set; }
    }
}
