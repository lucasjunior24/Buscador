using Buscador.Data.Context;
using Buscador.Interfaces;
using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Repository
{
    public class TrabalhadorRepository : Repository<Trabalhador>, ITrabalhadorRepository
    {

        public TrabalhadorRepository(BuscadorContext context) : base(context)
        { 
        }


        public async Task<Trabalhador> ObterTrabalhadorEnderecoPorUserId(Guid userId)
        {
            var trabalhador = await Db.Trabalhadores.AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.EnderecoTrabalhador).FirstOrDefaultAsync(t => t.UserId == userId);

            return trabalhador;
        }

        public async Task<Trabalhador> ObterTrabalhadorEnderecoEServico(Guid id)
        {
            var trabalhador = await Db.Trabalhadores.AsNoTracking()
                .Include(t => t.EnderecoTrabalhador).FirstOrDefaultAsync(t => t.Id == id);

            return trabalhador;
        }

        public async Task<Trabalhador> ObterTrabalhadorComCategoria(Guid id)
        {
            var trabalhador = await Db.Trabalhadores.AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.EnderecoTrabalhador).FirstOrDefaultAsync(t => t.Id == id);

            return trabalhador;
        }

        public async Task<IEnumerable<Trabalhador>> ObterTodosComCategoria()
        {
            var trabalhador = await Db.Trabalhadores.AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.EnderecoTrabalhador).ToListAsync();

            return trabalhador;
        }
    }
}
