using Buscador.Models.Entitiies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        Task<List<Solicitacao>> ObteSolicitacoesDoCliente(Guid userId);
        Task<List<Solicitacao>> ObteSolicitacoesDeTrabalhador(Guid trabalhadorId);
        Task<Solicitacao> ObterSolicitacaoPorId(Guid id);
    }
}
