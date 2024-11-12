using LgymApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LgymApp.Domain.Converters;

public class UtcDateTimeTruncateConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeTruncateConverter()
        : base(
            
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                         .RemoveMilliSeconds(),
            
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}
