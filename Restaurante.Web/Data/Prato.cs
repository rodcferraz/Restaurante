using System.ComponentModel.DataAnnotations;

namespace Restaurante.Web.Data
{
    public class Prato
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
