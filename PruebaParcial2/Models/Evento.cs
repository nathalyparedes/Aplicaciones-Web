using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaParcial2.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre del evento es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del evento no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "La fecha del evento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe tener un formato válido.")]
        [CustomValidation(typeof(Evento), nameof(ValidarFecha))]
        public DateTime Fecha { get; set; }
        
        [Required(ErrorMessage = "La hora del evento es obligatoria.")]
        [DataType(DataType.Time, ErrorMessage = "La hora debe tener un formato válido.")]
        public DateTime Hora { get; set; }
        
        [Required(ErrorMessage = "El ID del lugar es obligatorio.")]
        public int LugarId { get; set; }
        public Lugar? Lugar { get; set; }

        public static ValidationResult ValidarFecha(DateTime fecha, ValidationContext context)
        {
            if (fecha.Date < DateTime.Now.Date) // Comparar solo las fechas, ignorando la hora
            {
                return new ValidationResult("La fecha del evento no puede ser en el pasado.");
            }
            return ValidationResult.Success;
        }
}
}