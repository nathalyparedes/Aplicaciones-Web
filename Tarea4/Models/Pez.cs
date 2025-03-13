using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    public class Pez
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPez { get; set; }
        
        [Required(ErrorMessage = "El nombre común es requerido")]
        [Display(Name = "Nombre Común")]
        [StringLength(100)]
        public string NombreComun { get; set; }
        
        [Display(Name = "Nombre Científico")]
        [StringLength(100)]
        public string NombreCientifico { get; set; }
        
        [StringLength(100)]
        public string Especie { get; set; }
        
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime? FechaIngreso { get; set; }
        
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<PezHabitacion> PecesHabitaciones { get; set; }
        public virtual ICollection<Alimentacion> Alimentaciones { get; set; }
    }
}