using System.ComponentModel;

namespace Buscador.Utils.Enum
{
    public enum StatusDoAgendamento
    {
        [Description("Agendado")]
        Agendado = 0,
        [Description("Cancelado")]
        Cancelado = 1,
        [Description("Concluído")]
        Concluido = 2
    }
}
