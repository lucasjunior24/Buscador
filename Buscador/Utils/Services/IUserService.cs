using System.Threading.Tasks;

namespace Buscador.Utils.Services
{
    public interface IUserService
    {
        Task<string> ObterId();

        Task<string> ObterCpfCnpj();

        Task<string> ObterNome();

        Task<string> ObterEmail();

        Task<string> ObterPerfil();
    }
}