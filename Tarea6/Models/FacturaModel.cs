using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea5.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public DateOnly FechaIngreso { get; set; }
        [Display(Name ="Numero de Factura")]
        public int NumeroFactura { get; set; }   
        public int ClientesModelId { get; set; }
        public ClientesModel ClientesModel { get; set; }
    }
}