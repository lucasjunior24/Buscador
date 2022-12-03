using Buscador.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface IAgendamentoDoClienteRepository
    {
        Task<List<Agendamento>> ObterTodosPorClienteId(Guid clienteId);
    }
}
