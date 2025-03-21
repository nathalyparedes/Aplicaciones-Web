using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{   
    public class Habitat
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del hábitat es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del hábitat no puede superar los 100 caracteres.")]
        public string NombreHabitat { get; set; } = null!;

        [Required(ErrorMessage = "El tipo de agua es obligatorio.")]
        [RegularExpression("^(Dulce|Salada)$", ErrorMessage = "El tipo de agua debe ser 'Dulce' o 'Salada'.")]
        public string TipoAgua { get; set; } = null!; // "Dulce" o "Salada"

        [Required(ErrorMessage = "La temperatura promedio es obligatoria.")]
        [Range(-10, 100, ErrorMessage = "La temperatura promedio debe estar entre -10 y 100 grados Celsius.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TemperaturaPromedio { get; set; }

        [Required(ErrorMessage = "La capacidad en litros es obligatoria.")]
        [Range(1, 100000, ErrorMessage = "La capacidad en litros debe ser un valor positivo y razonable.")]
        public int CapacidadLitros { get; set; }

        // Relación con Animales
        public List<Animal> Animales { get; set; } = new();
        
        // Relación con Cuidadores (Muchos a Muchos)
        public List<CuidadorHabitat> CuidadoresHabitats { get; set; } = new();
    }
}
