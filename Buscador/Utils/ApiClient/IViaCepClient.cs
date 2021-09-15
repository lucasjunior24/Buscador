using Buscador.Models.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Utils.ApiClient
{
    public interface IViaCepClient
    {
        [Get("/ws/{cep}/json")]
        Task<RetornoViaCepDto> BuscarCep(string cep);
    }
}
