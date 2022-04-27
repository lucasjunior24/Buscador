using Buscador.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Buscador.ViewModels
{
    public class SolicitacaoViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Data da Solicitacao")]
        public DateTime DataDaSolicitacao { get; set; }
        public string FotoTrabalhador { get; set; }
        [Display(Name = "Nome do Trabalhador")]
        public string NomeDoTrabalhador { get; set; }
        [Display(Name = "Profissao do Trabalhador")]
        public string ProfissaoDoTrabalhador { get; set; }
        [Display(Name = "Nome do Cliente")]
        public string NomeDoCliente { get; set; }
        public Guid TrabalhadorId { get; set; }
        public Guid ClienteId { get; set; }
        [Display(Name = "Status da Solicitação")]
        public string StatusDaSolicitacao { get; set; }

        //Relacionamento
        public Trabalhador Trabalhador { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
