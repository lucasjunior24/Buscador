using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Buscador.Models.Services
{
    public class UploadArquivo : IUploadArquivo
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadArquivo(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> RealizarUploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            string projectRootPath = _hostingEnvironment.ContentRootPath;

            var path = Path.Combine(projectRootPath,
                                    "wwwroot/imagens",
                                    imgPrefixo + arquivo.FileName);

            if (File.Exists(path))
            {
                //ModelState.AddModelError(string.Empty, "Ja existe um arquivo com este nome!");
                return false;
            }

            // gravar arquivo em disco
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
