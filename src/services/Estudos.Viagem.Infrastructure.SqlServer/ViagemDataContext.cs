using Estudos.Viagem.Domain.Entities;
using Estudos.Viagem.Infrastructure.SqlServer.Converters;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Viagem.Infrastructure.SqlServer
{
    public class ViagemDataContext : DbContext
    {
        public ViagemDataContext(DbContextOptions options) : base(options) { }

        public DbSet<PacoteViagem> Viagens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateOnly>()
                 .HaveConversion<DateOnlyCustomConverter>()
                 .HaveColumnType("DATE");

            configurationBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyCustomConverter>()
                .HaveColumnType("TIME");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ViagemDataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
