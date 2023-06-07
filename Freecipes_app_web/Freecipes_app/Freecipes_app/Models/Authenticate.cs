using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Freecipes_app.Models
{
    public class Authenticate
    {

        public string Senha { get; set; }

        public string Email { get; set; }
    }
}
