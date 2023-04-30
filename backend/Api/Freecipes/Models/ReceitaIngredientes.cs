using backend_freecipes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_freecipes.Models
{
    [Table("ReceitaIngredientes")]
    public class ReceitaIngredientes
    {
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}