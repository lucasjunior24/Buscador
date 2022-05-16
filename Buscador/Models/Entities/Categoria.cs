namespace Buscador.Models.Entitiies
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public string Icone { get; set; }

        public Trabalhador Trabalhador { get; set; }
    }
}
