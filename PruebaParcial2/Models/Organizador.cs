using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaParcial2.Models
{
    public class Organizador
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre del organizador es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El tipo de organización es obligatorio.")]
        [StringLength(100, ErrorMessage = "El tipo de organización no puede exceder los 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El tipo de organización solo puede contener letras y espacios.")]
        public string TipoOrganizacion { get; set; }

    }
}