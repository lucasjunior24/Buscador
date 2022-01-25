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
    public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        public SolicitacaoRepository(BuscadorContext context) : base(context)
        {
        }

        public async Task<List<Solicitacao>> ObteSolicitacoesDeTrabalhador(Guid trabalhadorId)
        {
            var solicitacoes = await Db.Solicitacao.AsNoTracking()
                .Include(s => s.Trabalhador)
                .Where(s => s.TrabalhadorId == trabalhadorId).ToListAsync();

            return solicitacoes;
        }

        public async Task<List<Solicitacao>> ObteSolicitacoesDoCliente(Guid userId)
        {
            var solicitacoes = await Db.Solicitacao.AsNoTracking()
                .Include(s => s.Cliente)
                .Where(s => s.Cliente.UserId == userId).ToListAsync();

            return solicitacoes;
        }

        public async Task<Solicitacao> ObterSolicitacaoPorId(Guid id)
        {
            var solicitacao = await Db.Solicitacao.AsNoTracking()
               .Include(s => s.Cliente)
               .Include(s => s.Trabalhador)
               .FirstOrDefaultAsync(s => s.Id == id);

            return solicitacao;
        }
    }
}
