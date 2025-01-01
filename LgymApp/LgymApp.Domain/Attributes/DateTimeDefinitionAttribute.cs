using LgymApp.Domain.Enums;

namespace LgymApp.Domain.Attributes;

/// <summary>
/// Attribute to define the kind and component of a <seealso cref="DateTime"/> to truncate.
/// </summary>
public class DateTimeDefinitionAttribute : Attribute
{
    /// <summary>
    /// Gets the kind of the <seealso cref="DateTime"/>.
    /// </summary>
    public DateTimeKind Kind { get; }

    /// <summary>
    /// Gets the component of the <seealso cref="DateTime"/> to truncate.
    /// </summary>
    public DateTimeComponentsEnum DateTimeComponent { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeDefinitionAttribute"/> class.
    /// </summary>
    /// <param name="dateTimeComponent">The component of the <seealso cref="DateTime"/> to truncate.</param>
    /// <param name="kind">The kind of the <seealso cref="DateTime"/>. Default is <see cref="DateTimeKind.Utc"/>.</param>
    public DateTimeDefinitionAttribute(DateTimeComponentsEnum dateTimeComponent, DateTimeKind kind = DateTimeKind.Utc)
    {
        Kind = kind;
        DateTimeComponent = dateTimeComponent;
    }
}
