using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    public class Habitacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHabitacion { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "La capacidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad debe ser mayor a 0")]
        public int Capacidad { get; set; }
        
        [Required(ErrorMessage = "La temperatura ideal es requerida")]
        [Display(Name = "Temperatura Ideal")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TemperaturaIdeal { get; set; }
        
        [Required(ErrorMessage = "El nivel de agua es requerido")]
        [Display(Name = "Nivel de Agua")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal NivelAgua { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<PezHabitacion> PecesHabitaciones { get; set; }
    }
}