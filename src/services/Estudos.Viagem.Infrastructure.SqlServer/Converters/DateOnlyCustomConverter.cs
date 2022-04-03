using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estudos.Viagem.Infrastructure.SqlServer.Converters
{
    public class DateOnlyCustomConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyCustomConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)
        )
        { }
    }
}
