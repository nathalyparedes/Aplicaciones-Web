using Microsoft.AspNetCore.Identity;
//UUID
using System.ComponentModel.DataAnnotations;

namespace PruebaParcial2.Models
{
    public class UsuariosModel : IdentityUser
    {
        [Required]
        public string Cedula { get; set; }
    }
}