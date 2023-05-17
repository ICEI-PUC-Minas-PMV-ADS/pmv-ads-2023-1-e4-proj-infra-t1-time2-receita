using System.ComponentModel.DataAnnotations.Schema;

namespace Freecipes_app.Models
{
    [Table("Etapas")]
    public class Etapa
    {
        public int Id { get; set; }

        public int NumInstrucao { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public int ReceitaId { get; set; }

        public Receita Receita { get; set; }

    }
}
