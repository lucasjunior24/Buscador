using Buscador.Models;
using System;
using System.Threading.Tasks;

namespace Buscador.Interfaces
{
    public interface ITrabalhadorRepository : IRepository<Trabalhador>
    {
        Task<Trabalhador> ObterTrabalhadorEndereco(Guid id);
        Task<Trabalhador> ObterTrabalhadorEnderecoEServico(Guid id);
    }
}
