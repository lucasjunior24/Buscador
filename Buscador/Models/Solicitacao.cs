﻿using System;

namespace Buscador.Models
{
    public class Solicitacao : Entity
    {
        public DateTime DataDaSolicitacao { get; set; }
        public string NomeDoTrabalhador { get; set; }
        public string ProfissaoDoTrabalhador { get; set; }
        public string NomeDoCliente { get; set; }
        public bool Aprovado { get; set; }


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
