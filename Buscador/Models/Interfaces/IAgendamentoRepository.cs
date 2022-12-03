using Buscador.Models.Entities;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task Create(Agendamento agendamento);
    }
}
