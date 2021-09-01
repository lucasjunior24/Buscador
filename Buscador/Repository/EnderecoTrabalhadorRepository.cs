using Buscador.Data.Context;
using Buscador.Interfaces;
using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Repository
{
    public class EnderecoTrabalhadorRepository : Repository<EnderecoTrabalhador>, IEnderecoTrabalhadorRepository
    {
        public EnderecoTrabalhadorRepository(BuscadorContext db) : base(db)
        {
        }

        public async Task<EnderecoTrabalhador> ObterEnderecoPorTrabalhador(Guid trabalhadorId)
        {
            var enderecoTrabalhador = await Db.EnderecoDosTrabalhadores.AsNoTracking().FirstOrDefaultAsync(t => t.TrabalhadorId == trabalhadorId);
            return enderecoTrabalhador;
        }
    }
}
