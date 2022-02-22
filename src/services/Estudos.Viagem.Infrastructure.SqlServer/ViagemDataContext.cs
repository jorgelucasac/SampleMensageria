using Estudos.Viagem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estudos.Viagem.Infrastructure.SqlServer
{
    public class ViagemDataContext : DbContext
    {
        public ViagemDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PacoteViagem> Viagens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Hospedagem> Hospedagens { get; set; }
        public DbSet<Carro> Carros { get; set; }

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

    public class DateOnlyCustomConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyCustomConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)
        )
        { }
    }

    public class TimeOnlyCustomConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyCustomConverter() : base(
            d => d.ToTimeSpan(),
            d => TimeOnly.FromTimeSpan(d)
        )
        { }
    }

    //public static class DbInitializer
    //{
    //    public static void Initialize(ApplicationContext context)
    //    {
    //        if (!context.Cars.Any())
    //        {
    //            if (File.Exists("./Data/database.csv"))
    //            {
    //                string[] lines = File.ReadAllLines("./Data/database.csv");
    //                if (lines is not null && lines.Any())
    //                {
    //                    var carsInsert = lines
    //                        .Where(l => !string.IsNullOrEmpty(l))
    //                        .Select(line => new Car(line.Split(";")[0], line.Split(";")[1], int.Parse(line.Split(";")[2])))
    //                        .ToList();

    //                    context.Cars.AddRange(carsInsert);
    //                    context.SaveChanges();
    //                }
    //            }
    //        }
    //    }
    //}

    public class ViagemMapping : IEntityTypeConfiguration<PacoteViagem>
    {
        public void Configure(EntityTypeBuilder<PacoteViagem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.Passagem, e =>
            {
                e.Property(ps => ps.Origem)
                    .HasColumnName("Origem");

                e.Property(ps => ps.Destino)
                    .HasColumnName("Destino");

                e.Property(ps => ps.DataIda)
                    .HasColumnName("DataIda");

                e.Property(ps => ps.DataVolta)
                    .HasColumnName("DataVolta");

                e.Property(ps => ps.QuantidadeViajantes)
                    .HasColumnName("QuantidadeViajantes");
            });
        }
    }
}
