using System.ComponentModel;

namespace LgymApp.Domain.Enums;

/// <summary>
/// Enumeration representing units of weight data.
/// </summary>
public enum WeightDataUnitsEnum
{
    /// <summary>
    /// Kilograms unit.
    /// </summary>
    [Description("kg")]
    KILOGRAMS,

    /// <summary>
    /// Pounds unit.
    /// </summary>
    [Description("lbs")]
    POUNDS,
}
