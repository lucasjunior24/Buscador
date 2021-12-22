using Buscador.Models;
using System;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteEndereco(Guid id);
        Task<Cliente> ObterClienteEnderecoPorUserId(Guid userId);
    }
}
