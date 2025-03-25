using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Tarea5.Models
{
    public class ProveedoresModel
    {
        public int Id { get; set; }
        [Display(Name ="Nombre del Proveedor")]
        [Required(ErrorMessage ="El campo es requiro")]
        [MinLength(3, ErrorMessage ="El campo requiere mínimo 3 letras")]
        public string NombreProveedor { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo es requiro")]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string Direccion { get; set; }
        
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo es requiro")]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string Telefono { get; set; }
        
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress(ErrorMessage = "No es un formato de correo electrónico válido")]
        public string Correo { get; set; }

    }
}