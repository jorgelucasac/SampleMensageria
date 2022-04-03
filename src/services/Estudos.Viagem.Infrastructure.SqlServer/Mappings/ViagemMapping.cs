using Estudos.Viagem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estudos.Viagem.Infrastructure.SqlServer.Mappings
{
    public class ViagemMapping : IEntityTypeConfiguration<PacoteViagem>
    {
        public void Configure(EntityTypeBuilder<PacoteViagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Total)
                .HasColumnType("decimal(18,2)");

            builder.Ignore(x => x.Hospedagem);
            builder.Ignore(x => x.Carro);
            builder.Ignore(x => x.Carro);

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

            builder.OwnsOne(o => o.Hospedagem, e =>
            {
                e.Property(h => h.HotelId)
                    .HasColumnName("HotelId");

                e.Property(ps => ps.NomeHotel)
                    .HasColumnName("NomeHotel");

                e.Property(ps => ps.ValorDiaria)
                    .HasColumnName("ValorDiariaHotel")
                    .HasColumnType("decimal(18,2)");
            });

            builder.OwnsOne(c => c.Carro, e =>
            {
                e.Property(ca => ca.CarroId)
                    .HasColumnName("CarroId");

                e.Property(ps => ps.Modelo)
                    .HasColumnName("ModeloCarro");

                e.Property(ps => ps.Categoria)
                    .HasColumnName("CategoriaCarro");

                e.Property(ps => ps.ValorDiaria)
                    .HasColumnName("ValorDiariaCarro")
                    .HasColumnType("decimal(18,2)");
            });
        }
    }
}
