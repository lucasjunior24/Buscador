using Buscador.Models;
using System;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface IEnderecoTrabalhadorRepository : IRepository<EnderecoTrabalhador>
    {
        Task<EnderecoTrabalhador> ObterEnderecoPorTrabalhador(Guid trabalhadorId);
    }
}
