using System;

namespace Buscador.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public string Icone { get; set; }

        public Trabalhador Trabalhador { get; set; }
    }
}
