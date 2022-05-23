using Buscador.Models.Entitiies;
using System;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface IEnderecoClienteRepository : IRepository<EnderecoCliente>
    {
        Task<EnderecoCliente> ObterEnderecoPorCliente(Guid clienteId);
    }
}
