using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Buscador.Models.Services
{
    public interface IUploadArquivo
    {
        Task<bool> RealizarUploadArquivo(IFormFile arquivo, string imgPrefixo);
    }
}
