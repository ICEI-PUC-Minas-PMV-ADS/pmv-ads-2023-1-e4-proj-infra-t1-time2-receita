using System.ComponentModel.DataAnnotations.Schema;

namespace backend_freecipes.Models
{
    [Table("Etapas")]
    public class Etapa
    {
        public int Id { get; set; }

        public int NumInstrucao { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public ICollection<ReceitaEtapas> Receitas { get; set; }


    }
}
