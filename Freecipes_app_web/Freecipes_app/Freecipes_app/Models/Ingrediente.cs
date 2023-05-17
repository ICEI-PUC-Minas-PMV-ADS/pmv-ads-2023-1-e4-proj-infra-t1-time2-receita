using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Freecipes_app.Models
{
    [Table("Ingredientes")]
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string UnidadeMedida { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public int ReceitaId { get; set; }

        public Receita Receita { get; set; }

    }
}
