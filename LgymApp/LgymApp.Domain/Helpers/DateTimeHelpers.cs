namespace LgymApp.Domain.Helpers;

/// <summary>
/// Provides helper methods for manipulating DateTime objects.
/// </summary>
public static class DateTimeHelpers
{
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
