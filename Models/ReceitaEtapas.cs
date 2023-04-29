using backend_freecipes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_freecipes.Models
{
    [Table("ReceitaEtapas")]
    public class ReceitaEtapas
    {
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }
    }
}