using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Models
{
    public class Cliente : Usuario
    {
        public EnderecoCliente EnderecoCliente { get; set; }
    }
}
