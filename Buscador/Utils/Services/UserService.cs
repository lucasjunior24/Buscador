using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Utils.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task<string> ObterId()
        {
            //FakeLogin
            //Task<string> id = Task<string>.Factory.StartNew(() =>
            //{
            //    return "usuarioId";
            //});
            //return id;

            var id = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("sub"));
            return Task.FromResult(id != null ? id.Value : "");
        }

        public Task<string> ObterCpfCnpj()
        {
            //FakeLogin
            //Task<string> id = Task<string>.Factory.StartNew(() =>
            //{
            //    return "cpfCnpj";
            //});
            //return id;

            var cpf = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("movimentacao@Cpf"));
            return Task.FromResult(cpf != null ? cpf.Value : "");
        }

        public Task<string> ObterNome()
        {
            var nome = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "movimentacao@Nome");
            return Task.FromResult(nome != null ? nome.Value : "");
        }

        public Task<string> ObterEmail()
        {
            var email = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("movimentacao@Email"));
            return Task.FromResult(email != null ? email.Value : "");
        }

        public Task<string> ObterPerfil()
        {
            var perfil = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Perfil"));

            return Task.FromResult(perfil.Value);
        }
    }
}
