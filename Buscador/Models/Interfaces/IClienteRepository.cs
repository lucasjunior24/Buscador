using Buscador.Models.Entitiies;
using System;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteEndereco(Guid id);
        Task<Cliente> ObterClienteEnderecoPorUserId(Guid userId);
    }
}
