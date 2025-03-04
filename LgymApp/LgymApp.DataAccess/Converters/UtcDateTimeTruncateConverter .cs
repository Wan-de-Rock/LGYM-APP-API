using LgymApp.Domain.Enums;
using LgymApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LgymApp.DataAccess.Converters;

public class UtcDateTimeTruncateConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeTruncateConverter(DateTimeComponentsEnum dateTimeComponent = DateTimeComponentsEnum.Millisecond, DateTimeKind kind = DateTimeKind.Utc)
        : base(

            v => v.TransformDateTimeByKind(kind)
                  .TruncateComponent(dateTimeComponent),

            v => DateTime
                        .SpecifyKind(v, kind))
    {
    }
}

public class NullableUtcDateTimeTruncateConverter : ValueConverter<DateTime?, DateTime?>
{
    public NullableUtcDateTimeTruncateConverter(DateTimeComponentsEnum dateTimeComponent = DateTimeComponentsEnum.Millisecond, DateTimeKind kind = DateTimeKind.Utc)
        : base(
            v => v != null
                ? v.Value.TransformDateTimeByKind(kind).TruncateComponent(dateTimeComponent)
                : v,

            v => v != null
                ? DateTime.SpecifyKind(v.Value, kind)
                : v)
    {
    }
}