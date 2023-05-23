using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_freecipes.Models
{
    public class UsuarioDto
    {
        public int? Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

    }
}
