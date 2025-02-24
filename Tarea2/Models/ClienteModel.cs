using System.ComponentModel.DataAnnotations;

namespace Tarea2.Models
{
    public class ClienteModel
    {
     public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, ingrese la cédula o RUC.")]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "La cédula o RUC debe tener entre 10 y 13 caracteres.")]
    public string Cedula_RUC { get; set; }

    [Required(ErrorMessage = "El nombre es necesario.")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Por favor, ingrese un nombre válido (solo letras).")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es necesario.")]
    [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Por favor, ingrese un apellido válido (solo letras).")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "La dirección es importante.")]
    [StringLength(50, ErrorMessage = "La dirección no debe exceder los 50 caracteres.")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener exactamente 10 dígitos.")]
    public string Telefono { get; set; }

    // Propiedad opcional
    [Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 años.")]
    public int? Edad { get; set; }
    }
}