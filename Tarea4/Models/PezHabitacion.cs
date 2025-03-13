using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    public class PezHabitacion
    {
        [Key]
        [Column(Order = 0)]
        public int IdPez { get; set; }
        
        [Key]
        [Column(Order = 1)]
        public int IdHabitacion { get; set; }
        
        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.DateTime)]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        
        [Display(Name = "Fecha de Salida")]
        [DataType(DataType.Date)]
        public DateTime? FechaSalida { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdPez")]
        public virtual Pez Pez { get; set; }
        
        [ForeignKey("IdHabitacion")]
        public virtual Habitacion Habitacion { get; set; }
    }
}