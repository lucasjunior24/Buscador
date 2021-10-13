using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Models
{
    public class Solicitacao : Entity
    {
        public DateTime DataDaSolicitacao { get; set; }
        public string NomeSolicitante { get; set; }
        public string DocumentoSolicitante { get; set; }

        //Relacionamento
        public Guid TrabalhadorId { get; set; }
        public Trabalhador Trabalhador { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public void GravarDataDaSolicitacao()
        {
            DataDaSolicitacao = DateTime.Now;
        }
    }
}
