using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaParcial2.Models
{
        public class Lugar
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string Direccion { get; set; }

        [Range(1, 10000, ErrorMessage = "La capacidad debe estar entre 1 y 10,000.")]
        public int Capacidad { get; set; }
    }

}