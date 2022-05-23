using Buscador.Models.Entitiies;
using System;
using System.Threading.Tasks;

namespace Buscador.Models.Interfaces
{
    public interface IEnderecoTrabalhadorRepository : IRepository<EnderecoTrabalhador>
    {
        Task<EnderecoTrabalhador> ObterEnderecoPorTrabalhador(Guid trabalhadorId);
    }
}
