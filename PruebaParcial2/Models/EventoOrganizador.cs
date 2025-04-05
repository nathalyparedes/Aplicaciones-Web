using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaParcial2.Models
{
    public class EventoOrganizador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El evento es obligatorio.")]
        public int EventoId { get; set; }

        public Evento? Evento { get; set; }

        [Required(ErrorMessage = "El organizador es obligatorio.")]
        public int OrganizadorId { get; set; }

        public Organizador? Organizador { get; set; }
    }
}