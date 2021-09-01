using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Models
{
    public class EnderecoCliente : Endereco
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
