using Buscador.Data.Context;
using Buscador.Interfaces;
using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BuscadorContext db) : base(db)
        {
        }

        public async Task<Cliente> ObterClienteEndereco(Guid id)
        {
            var cliente = await Db.Clientes.AsNoTracking()
                .Include(c => c.EnderecoCliente).FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }
    }
}
