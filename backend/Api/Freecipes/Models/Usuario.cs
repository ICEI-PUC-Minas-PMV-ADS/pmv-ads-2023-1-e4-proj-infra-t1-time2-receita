using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_freecipes.Models
{
    [Table ("Usuarios")]
    public class Usuario:LinksHATEOS
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [JsonIgnore]
        public string Senha { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Receita> Receitas { get; set; }


    }

}
