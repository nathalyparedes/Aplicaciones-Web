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
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        public DateOnly Fecha { get; set; }
        
        [Required]
        public TimeOnly Hora { get; set; }
        
        public int LugarId { get; set; }
        
        [ForeignKey("LugarId")]
        public Lugar Lugar { get; set; }
        
        public ICollection<Participante> Participantes { get; set; }
        public ICollection<Organizador> Organizadores { get; set; }
    }
}