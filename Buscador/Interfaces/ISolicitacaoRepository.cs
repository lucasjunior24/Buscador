using Buscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        Task<List<Solicitacao>> ObterMinhasSolicitacoes(Guid clienteId);
        Task<Solicitacao> ObterSolicitacaoPorId(Guid id);
    }
}
