using Buscador.Models.Entitiies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface ITrabalhadorRepository : IRepository<Trabalhador>
    {
        Task<Trabalhador> ObterTrabalhadorComCategoria(Guid id);
        Task<IEnumerable<Trabalhador>> ObterTodosComCategoria();
        Task<Trabalhador> ObterTrabalhadorEnderecoPorUserId(Guid userId);
        Task<Trabalhador> ObterTrabalhadorEnderecoEServico(Guid id);
    }
}
