using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaParcial2.Models
{
    public class Participante
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre del participante es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El contacto del participante es obligatorio.")]
        [StringLength(10, ErrorMessage = "El contacto no puede exceder los 10 caracteres.")]
        [RegularExpression(@"^[0-9+\-\s]+$", ErrorMessage = "El contacto solo puede contener números")]
        public string Contacto { get; set; }

    }
}