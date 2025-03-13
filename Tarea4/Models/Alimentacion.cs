using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea4.Models
{
    public class Alimentacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlimentacion { get; set; }
        
        [Required]
        public int IdPez { get; set; }
        
        [Required]
        public int IdAlimento { get; set; }
        
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Cantidad { get; set; }
        
        [Required]
        [Display(Name = "Fecha de Alimentación")]
        [DataType(DataType.DateTime)]
        public DateTime FechaAlimentacion { get; set; } = DateTime.Now;
        
        // Propiedades de navegación
        [ForeignKey("IdPez")]
        public virtual Pez Pez { get; set; }
        
        [ForeignKey("IdAlimento")]
        public virtual Alimento Alimento { get; set; }
    }
}