using Buscador.ViewModels;
using System;
using System.Threading.Tasks;

namespace Buscador.Utils.Service
{
    public interface IPerfilService
    {
        Task<PerfilViewModel> ObterPerfilUserId(Guid userId);
    }

}
