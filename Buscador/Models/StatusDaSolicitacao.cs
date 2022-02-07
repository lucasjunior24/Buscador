﻿using System.ComponentModel;

namespace Buscador.Models
{
    public enum StatusDaSolicitacao
    {
        [Description("Aprovado")]
        Aprovado,
        [Description("Aguardando Aprovação")]
        AguardandoAprovacao,
        [Description("Em Analise")]
        EmAnalise,
        [Description("Reprovado")]
        Reprovado,
    }
}
