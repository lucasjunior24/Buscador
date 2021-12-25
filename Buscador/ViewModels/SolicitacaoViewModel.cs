using System;

namespace Buscador.ViewModels
{
    public class SolicitacaoViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public string NomeSolicitante { get; set; }
        public string NomeTrabalhador { get; set; }
        public string ProfisssaoDoTrabalhador { get; set; }

        //Relacionamento
        public Guid TrabalhadorId { get; set; }
        public Guid ClienteId { get; set; }
        public TrabalhadorViewModel Trabalhador { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
