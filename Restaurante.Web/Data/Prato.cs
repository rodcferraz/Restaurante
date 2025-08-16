using System.ComponentModel.DataAnnotations;

namespace Restaurante.Web.Data
{
    public class Prato
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        public ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
        public bool Ativo { get; set; } = true;
    }
}
