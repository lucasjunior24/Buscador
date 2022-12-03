using Buscador.Models.Entitiies;
using Buscador.Utils.Enum;
using System;

namespace Buscador.Models.ViewModels
{
    public class AgendamentoViewModel
    {
        public DateTime DataDoAgendamento { get; set; }
        public Guid TrabalhadorId { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DiaAgendado { get; set; }
        public StatusDoAgendamento StatusDoAgendamento { get; set; }

        public Trabalhador Trabalhador { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
