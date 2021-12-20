using Buscador.Data;
using Buscador.Data.Context;
using Buscador.Extensions;
using Buscador.Interfaces;
using Buscador.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buscador
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BuscadorContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("trabalhador", policy => policy.RequireClaim("trabalhador"));
                options.AddPolicy("Cliente", policy => policy.RequireClaim("Cliente"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
            });


            services.AddAutoMapper(typeof(Startup));

            services.AddApiClients(Configuration);

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<BuscadorContext>();

            services.AddScoped<ITrabalhadorRepository, TrabalhadorRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoDeServicoRepository, TipoDeServicoRepository>();
            services.AddScoped<IEnderecoTrabalhadorRepository, EnderecoTrabalhadorRepository>();
            services.AddScoped<IEnderecoClienteRepository, EnderecoClienteRepository>();

            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
