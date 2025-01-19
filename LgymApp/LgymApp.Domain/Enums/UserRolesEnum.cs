namespace LgymApp.Domain.Enums;

/// <summary>
/// Enumeration representing the different user roles in the application.
/// </summary>
public enum UserRolesEnum
{
    /// <summary>
    /// Represents the system user with the highest level of privileges.
    /// </summary>
    System,

    /// <summary>
    /// Represents an administrator user with elevated privileges.
    /// </summary>
    Admin,

    /// <summary>
    /// Represents a trainer user with specific privileges.
    /// </summary>
    Trainer,

    /// <summary>
    /// Represents a normal user with standard privileges.
    /// </summary>
    Normal,
}
