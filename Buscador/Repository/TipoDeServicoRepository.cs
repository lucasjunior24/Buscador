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
    public class TipoDeServicoRepository : Repository<TipoDeServico>, ITipoDeServicoRepository
    {
        public TipoDeServicoRepository(BuscadorContext db) : base(db)
        {
        }

        public async Task<TipoDeServico> ObterTipoDeServicoPorTrabalhador(Guid trabalhadorId)
        {
            return await Db.TiposDeServicos.AsNoTracking().FirstOrDefaultAsync(ts => ts.TrabalhadorId == trabalhadorId);
        }

        public async Task<TipoDeServico> ObterTipoDeServicoTrabalhador(Guid id)
        {
            return await Db.TiposDeServicos.AsNoTracking().Include(ts => ts.Trabalhador).FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<IEnumerable<TipoDeServico>> ObterTodosTiposDeServicos()
        {
            var todosTiposDeServicosComTrabalhadores = await Db.TiposDeServicos.AsNoTracking().Include(ts => ts.Trabalhador).OrderBy(ts => ts.NomeDoServico).ToListAsync();
            return todosTiposDeServicosComTrabalhadores;
        }
    }
}
