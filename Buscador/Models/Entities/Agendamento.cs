using Buscador.Models.Entitiies;
using Buscador.Utils.Enum;
using System;

namespace Buscador.Models.Entities
{
    public class Agendamento : Entity
    {
        public DateTime DataDoAgendamento { get; set; }
        public StatusDoAgendamento StatusDoAgendamento { get; set; }
        public DateTime DiaAgendado { get; set; }

        //Relacionamento
        public Guid TrabalhadorId { get; set; }
        public Guid ClienteId { get; set; }
        public Trabalhador Trabalhador { get; set; }
        public Cliente Cliente { get; set; }

        public void GravarDataDoAgendamento()
        {
            DataDoAgendamento = DateTime.Now;
        }
    }
}
