using System;

namespace Buscador.Models.Entitiies
{
    public class EnderecoCliente : Endereco
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
