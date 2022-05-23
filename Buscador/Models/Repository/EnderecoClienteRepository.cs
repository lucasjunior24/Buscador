using Buscador.Data.Context;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Models.Repository
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
