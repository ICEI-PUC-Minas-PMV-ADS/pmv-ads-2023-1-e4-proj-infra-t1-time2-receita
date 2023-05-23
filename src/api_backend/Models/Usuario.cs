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

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        [JsonIgnore]
        public string Senha { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public string Email { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public ICollection<Receita> Receitas { get; set; }


    }

}
