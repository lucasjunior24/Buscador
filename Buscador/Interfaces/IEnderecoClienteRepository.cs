using Buscador.Models;
using System;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface IEnderecoClienteRepository : IRepository<EnderecoCliente>
    {
        Task<EnderecoCliente> ObterEnderecoPorCliente(Guid clienteId);
    }
}
