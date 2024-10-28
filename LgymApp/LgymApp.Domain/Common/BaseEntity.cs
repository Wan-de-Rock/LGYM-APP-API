using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Common;

/// <summary>
/// Represents the base entity with common properties for all entities.
/// </summary>
[Index(nameof(Id), IsUnique = true)]
public abstract class BaseEntity
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// Gets a value indicating whether the entity is deleted.
    /// </summary>
    public bool IsDeleted { get; private set; } = false;

    /// <summary>
    /// Gets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the date and time when the entity was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// Marks the entity as deleted or not deleted.
    /// </summary>
    /// <param name="deleted">If set to <c>true</c>, marks the entity as deleted.</param>
    public void SetDeleted(bool deleted = true) => IsDeleted = deleted;

    /// <summary>
    /// Sets the date and time when the entity was last updated.
    /// </summary>
    /// <param name="updateAt">The date and time to set as the last updated time.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified date and time is earlier than the current <see cref="UpdatedAt"/> value.</exception>
    public void SetUpdateAt(DateTime updateAt) =>
        UpdatedAt = updateAt >= UpdatedAt
        ? updateAt
        : throw new ArgumentOutOfRangeException(nameof(updateAt));
}
