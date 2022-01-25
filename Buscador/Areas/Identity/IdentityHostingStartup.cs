using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Buscador.Areas.Identity.IdentityHostingStartup))]
namespace Buscador.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}