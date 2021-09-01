using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Models
{
    public class EnderecoTrabalhador : Endereco
    {
        public Guid TrabalhadorId { get; set; }
        public Trabalhador Trabalhador { get; set; }
    }
}
