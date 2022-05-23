using Buscador.Data.Context;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Models.Repository
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
        public async Task<Cliente> ObterClienteEnderecoPorUserId(Guid userId)
        {
            var cliente = await Db.Clientes.AsNoTracking()
                .Include(c => c.EnderecoCliente).FirstOrDefaultAsync(c => c.UserId == userId);

            return cliente;
        }

    }
}
