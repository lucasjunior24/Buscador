using System;

namespace Buscador.Models
{
    public class TipoDeServico : Entity
    {
        public Guid TrabalhadorId { get; set; }
        public string NomeDoServico { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string AreaProfissional { get; set; }
        public DateTime DataCadastro { get; set; }

        /* EF Relation  */

        /// Trabalhador tem apenas um tipo de serviço
        public Trabalhador Trabalhador { get; set; }
    }
}
