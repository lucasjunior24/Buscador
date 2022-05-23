using Buscador.Data.Context;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Models.Repository
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
