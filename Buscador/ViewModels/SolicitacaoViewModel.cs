using Buscador.Models;
using System;

namespace Buscador.ViewModels
{
    public class SolicitacaoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public string NomeDoTrabalhador { get; set; }
        public string ProfissaoDoTrabalhador { get; set; }
        public string NomeDoCliente { get; set; }
        public Guid TrabalhadorId { get; set; }
        public Guid ClienteId { get; set; }
        public string StatusDaSolicitacao { get; set; }

        //Relacionamento
        public Trabalhador Trabalhador { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
