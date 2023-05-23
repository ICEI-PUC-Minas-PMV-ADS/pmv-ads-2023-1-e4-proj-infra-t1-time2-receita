using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace backend_freecipes.Models
{
    [Table("Receitas")]
    public class Receita:LinksHATEOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Tempo { get; set; }
        [Required]
        public int Rendimento { get; set; }
        [Display(Name = "Ingredientes")]
        [Required]
        public string Ingrediente { get; set; }
        [Display(Name = "Modo de preparo")]
        [Required]
        public string Etapa { get; set; }
        [Required]
        public DateTime Dt_receita { get; set; }
        [Required]
        public GrauDificuldade Dificuldade { get; set; }
        [Required]
        public Categoria Categoria { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }


    }

    public enum GrauDificuldade
    {
        [Display(Name = "Facil")]
        Facil,
        [Display(Name = "Medio")]
        Medio,
        [Display(Name = "Dificil")]
        Dificil
    }
    public enum Categoria
    {
        [Display(Name = "Café da manhã")]
        CafeManha,
        [Display(Name = "Almoço/Jantar")]
        AlmocoJantar,
        [Display(Name = "Sobremesa")]
        Sobremesa,
        [Display(Name = "Lanche")]
        Lanche
    }

}
