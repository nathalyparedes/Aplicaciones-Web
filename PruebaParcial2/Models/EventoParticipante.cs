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
    
    public int EventoId { get; set; }
    public Evento Evento { get; set; }
    
    public int ParticipanteId { get; set; }
    public Participante Participante { get; set; }
}
}