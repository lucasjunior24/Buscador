using Buscador.Data.Context;
using Buscador.Interfaces;
using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Buscador.Repository
{
    public class TrabalhadorRepository : Repository<Trabalhador>, ITrabalhadorRepository
    {
        public TrabalhadorRepository(BuscadorContext context) : base(context)
        {
        }

        public async Task<Trabalhador> ObterTrabalhadorEndereco(Guid id)
        {
            var trabalhador = await Db.Trabalhadores.AsNoTracking()
                .Include(t => t.EnderecoTrabalhador).FirstOrDefaultAsync(t => t.Id == id);

            return trabalhador;
        }

        public async Task<Trabalhador> ObterTrabalhadorEnderecoEServico(Guid id)
        {
            var trabalhador = await Db.Trabalhadores.AsNoTracking()
                .Include(t => t.TipoDeServico)
                .Include(t => t.EnderecoTrabalhador).FirstOrDefaultAsync(t => t.Id == id);

            return trabalhador;
        }
    }
}
