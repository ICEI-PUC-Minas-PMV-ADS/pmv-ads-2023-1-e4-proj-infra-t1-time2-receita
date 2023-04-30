using System.ComponentModel.DataAnnotations;

namespace backend_freecipes.Models
{
    public class AuthenticateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
