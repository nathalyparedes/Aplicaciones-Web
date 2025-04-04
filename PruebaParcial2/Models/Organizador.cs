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
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(100)]
        public string TipoOrganizacion { get; set; }
    }
}