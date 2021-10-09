using Buscador.Models;
using Microsoft.EntityFrameworkCore;

namespace Buscador.Data.Context
{
    public class BuscadorContext : DbContext
    {
        public BuscadorContext(DbContextOptions<BuscadorContext> options) : base(options) { }

        public DbSet<Trabalhador> Trabalhadores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoCliente> EnderecoDosClientes { get; set; }
        public DbSet<EnderecoTrabalhador> EnderecoDosTrabalhadores { get; set; }
        public DbSet<TipoDeServico> TiposDeServicos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BuscadorContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
