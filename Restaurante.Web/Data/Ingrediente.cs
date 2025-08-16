using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Restaurante.Web.Data
{
    public class Ingrediente
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Prato> Pratos { get; set; } = new List<Prato>();

        public bool Ativo { get; set; } = true;
    }
}
