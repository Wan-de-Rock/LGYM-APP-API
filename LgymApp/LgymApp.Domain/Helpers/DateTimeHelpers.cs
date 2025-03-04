using LgymApp.Domain.Enums;

namespace LgymApp.Domain.Helpers;

/// <summary>
/// Provides helper methods for manipulating DateTime objects.
/// </summary>
public static class DateTimeHelpers
{
    /// <summary>
    /// Transforms the specified DateTime to the specified DateTimeKind.
    /// </summary>
    /// <param name="dateTime">The DateTime to transform.</param>
    /// <param name="kind">The DateTimeKind to transform to.</param>
    /// <returns>A DateTime transformed to the specified DateTimeKind.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified DateTimeKind is not supported.</exception>
    public static DateTime TransformDateTimeByKind(this DateTime dateTime, DateTimeKind kind)
    {
        return kind switch
        {
            DateTimeKind.Utc => dateTime.ToUniversalTime(),
            DateTimeKind.Local => dateTime.ToLocalTime(),
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "Kind is not supported")
        };
    }

    #region Remove methods

    /// <summary>
    /// Truncates the specified nullable DateTime to the given component.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to truncate.</param>
    /// <param name="component">The component to truncate to.</param>
    /// <returns>A truncated nullable DateTime.</returns>
    public static DateTime? TruncateComponent(this DateTime? dateTime, DateTimeComponentsEnum component)
        => dateTime.IsNullOrEmpty() ? dateTime : dateTime!.Value.TruncateComponent(component);

    /// <summary>
    /// Truncates the specified DateTime to the given component.
    /// </summary>
    /// <param name="dateTime">The DateTime to truncate.</param>
    /// <param name="component">The component to truncate to.</param>
    /// <returns>A truncated DateTime.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified component is not supported.</exception>
    public static DateTime TruncateComponent(this DateTime dateTime, DateTimeComponentsEnum component)
    {
        return component switch
        {
            DateTimeComponentsEnum.Year => dateTime.RemoveYears(),
            DateTimeComponentsEnum.Month => dateTime.RemoveMonths(),
            DateTimeComponentsEnum.Day => dateTime.RemoveDays(),
            DateTimeComponentsEnum.Hour => dateTime.RemoveHours(),
            DateTimeComponentsEnum.Minute => dateTime.RemoveMinutes(),
            DateTimeComponentsEnum.Second => dateTime.RemoveSeconds(),
            DateTimeComponentsEnum.Millisecond => dateTime.RemoveMilliSeconds(),
            _ => throw new ArgumentOutOfRangeException(nameof(component), component, "Component is not supported")
        };
    }

    /// <summary>
    /// Removes the years from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without years.</returns>
    public static DateTime RemoveYears(this DateTime dateTime)
        => new DateTime(0, dateTime.Kind);

    /// <summary>
    /// Removes the years from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without years.</returns>
    public static DateTime? RemoveYears(this DateTime? dateTime)
        => dateTime.IsNullOrEmpty() ? dateTime : dateTime.RemoveYears();

    /// <summary>
    /// Removes the months from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without months.</returns>
    public static DateTime RemoveMonths(this DateTime dateTime)
        => RemoveYears(dateTime).AddYears(dateTime.Year);

    /// <summary>
    /// Removes the months from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without months.</returns>
    public static DateTime? RemoveMonths(this DateTime? dateTime)
        => dateTime.IsNullOrEmpty() ? dateTime : dateTime.RemoveMonths();

    /// <summary>
    /// Removes the days from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without days.</returns>
    public static DateTime RemoveDays(this DateTime dateTime)
        => RemoveYears(dateTime).AddYears(dateTime.Year).AddMonths(dateTime.Month);

    /// <summary>
    /// Removes the days from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without days.</returns>
    public static DateTime? RemoveDays(this DateTime? dateTime)
        => dateTime.IsNullOrEmpty() ? dateTime : dateTime.RemoveDays();

    /// <summary>
    /// Removes the hours from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without hours.</returns>
    public static DateTime RemoveHours(this DateTime dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerDay);

    /// <summary>
    /// Removes the hours from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without hours.</returns>
    public static DateTime? RemoveHours(this DateTime? dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerDay);

    /// <summary>
    /// Removes the minutes from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without minutes.</returns>
    public static DateTime RemoveMinutes(this DateTime dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerHour);

    /// <summary>
    /// Removes the minutes from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without minutes.</returns>
    public static DateTime? RemoveMinutes(this DateTime? dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerHour);

    /// <summary>
    /// Removes the seconds from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without seconds.</returns>
    public static DateTime RemoveSeconds(this DateTime dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerMinute);

    /// <summary>
    /// Removes the seconds from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without seconds.</returns>
    public static DateTime? RemoveSeconds(this DateTime? dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerMinute);

    /// <summary>
    /// Removes the milliseconds from the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify.</param>
    /// <returns>A DateTime without milliseconds.</returns>
    public static DateTime RemoveMilliSeconds(this DateTime dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerSecond);

    /// <summary>
    /// Removes the milliseconds from the specified nullable DateTime.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to modify.</param>
    /// <returns>A nullable DateTime without milliseconds.</returns>
    public static DateTime? RemoveMilliSeconds(this DateTime? dateTime)
        => dateTime.Truncate(TimeSpan.TicksPerSecond);

    /// <summary>
    /// Truncates the specified nullable DateTime to the given resolution.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to truncate.</param>
    /// <param name="resolution">The resolution to truncate to.</param>
    /// <returns>A truncated nullable DateTime.</returns>
    public static DateTime? Truncate(this DateTime? dateTime, long resolution)
    {
        if (IsNullOrEmpty(dateTime)) return dateTime;
        return dateTime!.Value.Truncate(resolution);
    }

    /// <summary>
    /// Truncates the specified DateTime to the given resolution.
    /// </summary>
    /// <param name="dateTime">The DateTime to truncate.</param>
    /// <param name="resolution">The resolution to truncate to.</param>
    /// <returns>A truncated DateTime.</returns>
    public static DateTime Truncate(this DateTime dateTime, long resolution)
    {
        return dateTime.AddTicks(-(dateTime.Ticks % resolution));
    }

    #endregion

    /// <summary>
    /// Determines whether the specified nullable DateTime is null or empty.
    /// </summary>
    /// <param name="dateTime">The nullable DateTime to check.</param>
    /// <returns>True if the nullable DateTime is null or empty; otherwise, false.</returns>
    public static bool IsNullOrEmpty(this DateTime? dateTime)
    {
        return dateTime is null || dateTime.Value.IsNullOrEmpty();
    }

    /// <summary>
    /// Determines whether the specified DateTime is empty.
    /// </summary>
    /// <param name="dateTime">The DateTime to check.</param>
    /// <returns>True if the DateTime is empty; otherwise, false.</returns>
    public static bool IsNullOrEmpty(this DateTime dateTime)
    {
        return dateTime == DateTime.MinValue;
    }
}
