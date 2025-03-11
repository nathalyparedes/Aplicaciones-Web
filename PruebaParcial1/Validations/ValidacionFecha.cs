using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaParcial1.Validations
{
    public class ValidacionFechaAttribute : ValidationAttribute
    {
        // Constructor
        public ValidacionFechaAttribute() : base("La fecha de publicación debe ser menor que la fecha actual.")
        {
        }

        public override bool IsValid(object value)
        {
            if (value is DateOnly fecha)
            {
                // Compara la fecha proporcionada con la fecha actual
                return fecha < DateOnly.FromDateTime(DateTime.Now);
            }
            return true; // Si no es una fecha válida, no hay error
        }
    }
}
