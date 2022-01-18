using Buscador.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        Task<List<Solicitacao>> ObteSolicitacoesDoCliente(Guid userId);
        Task<List<Solicitacao>> ObteSolicitacoesDoTrabalhador(Guid trabalhadorId);
        Task<Solicitacao> ObterSolicitacaoPorId(Guid id);
    }
}
