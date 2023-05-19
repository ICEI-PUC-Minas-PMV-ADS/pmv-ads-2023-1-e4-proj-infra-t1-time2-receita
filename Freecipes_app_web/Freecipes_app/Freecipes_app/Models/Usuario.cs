using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Freecipes_app.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        [DataType(DataType.Password)] //inserir criptografia na caixa de senha (****)
        public string Senha { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "*Campo Obrigatório")]
        public string Email { get; set; }

        public ICollection<Receita> Receitas { get; set; }


    }
}
