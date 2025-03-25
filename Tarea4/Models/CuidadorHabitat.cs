using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea4.Models
{
    public class CuidadorHabitat
    {

         public int Id { get; set; }
         
        [Required(ErrorMessage = "El identificador del cuidador es obligatorio.")]
        public int CuidadorId { get; set; }

        [Required(ErrorMessage = "El cuidador asociado es obligatorio.")]
        public Cuidador Cuidador { get; set; }

        [Required(ErrorMessage = "El identificador del hábitat es obligatorio.")]
        public int HabitatId { get; set; }

        [Required(ErrorMessage = "El hábitat asociado es obligatorio.")]
        public Habitat Habitat { get; set; }
    }
}
