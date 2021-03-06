using Buscador.Data;
using Buscador.Data.Context;
using Buscador.Extensions;
using Buscador.Models.Interfaces;
using Buscador.Models.Repository;
using Buscador.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            services.AddControllersWithViews(o =>
            {
                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddRazorRuntimeCompilation();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<BuscadorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("trabalhador", policy => policy.RequireClaim("trabalhador"));
                options.AddPolicy("cliente", policy => policy.RequireClaim("cliente"));
                options.AddPolicy("admin", policy => policy.RequireClaim("admin"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddApiClients(Configuration);
            services.AddRazorPages();
            services.AddScoped<BuscadorContext>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITrabalhadorRepository, TrabalhadorRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoDeServicoRepository, TipoDeServicoRepository>();
            services.AddScoped<IEnderecoTrabalhadorRepository, EnderecoTrabalhadorRepository>();
            services.AddScoped<IEnderecoClienteRepository, EnderecoClienteRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();

            services.AddScoped<IUploadArquivo, UploadArquivo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                //app.UseDatabaseErrorPage();   
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UsarCulturaBrasileira();

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
