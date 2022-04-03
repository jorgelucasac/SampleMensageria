using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estudos.Viagem.Infrastructure.SqlServer.Converters;

public class TimeOnlyCustomConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyCustomConverter() : base(
        d => d.ToTimeSpan(),
        d => TimeOnly.FromTimeSpan(d)
    )
    { }
}
