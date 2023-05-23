using System.ComponentModel.DataAnnotations;

namespace backend_freecipes.Models
{
    public class AuthenticateDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
