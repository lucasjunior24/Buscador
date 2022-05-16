using Buscador.Models.Entitiies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface ITipoDeServicoRepository : IRepository<TipoDeServico>
    {
        Task<TipoDeServico> ObterTipoDeServicoPorTrabalhador(Guid trabalhadorId);
        Task<IEnumerable<TipoDeServico>> ObterTodosTiposDeServicos();
        Task<TipoDeServico> ObterTipoDeServicoTrabalhador(Guid id);
    }
}
