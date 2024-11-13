using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Common;

/// <summary>
/// Represents an entity that includes audit information such as creation and modification user.
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    /// <summary>
    /// Gets the date and time when the entity was created.
    /// </summary>
    [Required] public DateTime CreatedAt { get; }

    /// <summary>
    /// Gets the date and time when the entity was last updated.
    /// </summary>
    [Required] public DateTime UpdatedAt { get; }

    /// <summary>
    /// Gets the identifier of the user who created the entity.
    /// </summary>
    [Required] public Guid CreatedBy { get; private set; }

    /// <summary>
    /// Gets the identifier of the user who last updated the entity.
    /// </summary>
    [Required] public Guid UpdatedBy { get; private set; }
}

