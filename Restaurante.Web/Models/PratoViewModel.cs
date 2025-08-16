namespace Restaurante.Web.Models
{
    public class PratoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Guid> Ingredientes { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
