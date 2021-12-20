using Buscador.Interfaces;
using Buscador.ViewModels;
using System;
using System.Threading.Tasks;

namespace Buscador.Utils.Service
{
    public class PerfilService : IPerfilService
    {
        private readonly ITrabalhadorRepository _trabalhadorRepository;

        public PerfilService(ITrabalhadorRepository trabalhadorRepository)
        {
            _trabalhadorRepository = trabalhadorRepository;
        }

        public async Task<PerfilViewModel> ObterPerfilUserId(Guid userId)
        {
            var trabalhador = await _trabalhadorRepository.ObterTrabalhadorEnderecoPorUserId(userId);
            if (trabalhador != null)
            {
                var perfilTra = new PerfilViewModel();

                perfilTra.PerfilDeUsuario = "Trabalhador";

                return perfilTra;
            }

            var perfilViewModel = new PerfilViewModel();
            perfilViewModel.PerfilDeUsuario = "Cliente";

            return perfilViewModel;
        }
    }
}
