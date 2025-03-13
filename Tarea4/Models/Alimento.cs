using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    public class Alimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlimento { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [StringLength(50)]
        public string Tipo { get; set; }
        
        [Required(ErrorMessage = "La cantidad disponible es requerida")]
        [Display(Name = "Cantidad Disponible")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a 0")]
        public decimal CantidadDisponible { get; set; }
        
        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<Alimentacion> Alimentaciones { get; set; }
    }
}