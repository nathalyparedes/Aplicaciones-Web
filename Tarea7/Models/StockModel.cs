using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tarea7.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Fabricación")]
        public DateOnly FechaFabricacion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateOnly FechaCaducidad { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateOnly FechaRegistro { get; set; }
        
        public float precioUnitario { get; set; }
        public float precioVenta { get; set; }

        public bool estado { get; set; }

        [NotMapped]
        public string PrecioFinalCalculado { get; set; }
        public int ProductoModelId { get; set; }
        public ProductoModel ProductoModel { get; set; }

        public int ProveedoresModelId { get; set; }
        public ProveedoresModel ProveedoresModel { get; set; }
    }
}