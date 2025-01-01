using LgymApp.Domain.Enums;
using LgymApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LgymApp.DataAccess.Converters;

public class UtcDateTimeTruncateConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeTruncateConverter(DateTimeComponentsEnum dateTimeComponent = DateTimeComponentsEnum.Millisecond, DateTimeKind kind = DateTimeKind.Utc)
        : base(

            v => v.TransformDateTimeByKind(kind)
                  .RemoveComponent(dateTimeComponent),

            v => DateTime
                        .SpecifyKind(v, kind))
    {
    }
}
