using Microsoft.AspNetCore.Identity;
//UUID
using System.ComponentModel.DataAnnotations;

namespace Tarea7.Models
{
    public class UsuariosModel : IdentityUser
    {
        [Required]
        public string Cedula { get; set; }
    }
}