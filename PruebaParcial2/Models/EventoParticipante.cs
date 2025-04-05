using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace   PruebaParcial2.Models
{
    public class EventoParticipante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El evento es obligatorio.")]
        public int EventoId { get; set; }

        public Evento? Evento { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe tener un formato válido.")]
        [CustomValidation(typeof(EventoParticipante), nameof(ValidarFechaInscripcion))]
        public DateTime FechaInscripcion { get; set; }

        [Required(ErrorMessage = "El participante es obligatorio.")]
        public int ParticipanteId { get; set; }

        public Participante? Participante { get; set; }

        public static ValidationResult ValidarFechaInscripcion(DateTime fecha, ValidationContext context)
        {
            if (fecha.Date > DateTime.Now.Date)
            {
                return new ValidationResult("La fecha de inscripción no puede ser mayor al día actual.");
            }
            return ValidationResult.Success;
        }
    }
}