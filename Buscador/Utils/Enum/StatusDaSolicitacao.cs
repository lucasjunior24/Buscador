using System.ComponentModel;

namespace Buscador.Utils.Enum
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
