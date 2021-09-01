using Buscador.Data.Context;
using Buscador.Interfaces;
using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Repository
{
    public class EnderecoClienteRepository : Repository<EnderecoCliente>, IEnderecoClienteRepository
    {
        public EnderecoClienteRepository(BuscadorContext db) : base(db)
        {
        }

        public async Task<EnderecoCliente> ObterEnderecoPorCliente(Guid clienteId)
        {
            var enderecoCliente = await Db.EnderecoDosClientes.AsNoTracking().FirstOrDefaultAsync(c => c.ClienteId == clienteId);
            return enderecoCliente;
        }
    }
}
