using Buscador.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface ITrabalhadorRepository : IRepository<Trabalhador>
    {
        Task<Trabalhador> ObterTrabalhadorComCategoria(Guid id);
        Task<IEnumerable<Trabalhador>> ObterTodosComCategoria();
        Task<Trabalhador> ObterTrabalhadorEnderecoPorUserId(Guid userId);
        Task<Trabalhador> ObterTrabalhadorEnderecoEServico(Guid id);
    }
}
