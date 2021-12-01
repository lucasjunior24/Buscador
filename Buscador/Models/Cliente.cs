using System.Collections.Generic;

namespace Buscador.Models
{
    public class Cliente : Usuario
    {
        public EnderecoCliente EnderecoCliente { get; set; }
        public List<Solicitacao> Solicitacao { get; set; }
    }
}
