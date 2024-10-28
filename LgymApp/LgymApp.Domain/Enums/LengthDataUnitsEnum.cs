using System.ComponentModel;

namespace LgymApp.Domain.Enums;

/// <summary>
/// Enumeration representing different units of length measurement.
/// </summary>
public enum LengthDataUnitsEnum
{
    /// <summary>
    /// Centimeters (cm).
    /// </summary>
    [Description("cm")]
    CENTIMETERS,

    /// <summary>
    /// Inches (inch).
    /// </summary>
    [Description("inch")]
    INCHES,

    /// <summary>
    /// Meters (m).
    /// </summary>
    [Description("m")]
    METERS,

    /// <summary>
    /// Millimeters (mm).
    /// </summary>
    [Description("mm")]
    MILIMETERS,
}
