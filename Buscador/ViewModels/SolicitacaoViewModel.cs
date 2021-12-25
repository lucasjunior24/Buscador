using Buscador.Models;
using System;

namespace Buscador.ViewModels
{
    public class SolicitacaoViewModel
    {
        public DateTime DataDaSolicitacao { get; set; }
        public string NomeSolicitante { get; set; }
        public string DocumentoSolicitante { get; set; }

        //Relacionamento
        public Trabalhador Trabalhador { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
