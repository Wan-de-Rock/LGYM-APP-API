using LgymApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.Domain.Common;

/// <summary>
/// Represents the base entity with common properties for all entities.
/// </summary>
[PrimaryKey(nameof(Id))]
public abstract class BaseEntity : IEntity
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets a value indicating whether the entity is deleted.
    /// </summary>
    public bool IsDeleted { get; private set; } = false;

    /// <summary>
    /// Gets the date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the date and time when the entity was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// Marks the entity as deleted or not deleted.
    /// </summary>
    /// <param name="deleted">If set to <c>true</c>, marks the entity as deleted.</param>
    public void SetDeleted(bool deleted = true) => IsDeleted = deleted;

    public void SetUpdatedAt(DateTime updatedAt) => 
        UpdatedAt = updatedAt >= CreatedAt ? updatedAt
        : throw new ArgumentException(nameof(updatedAt), "Updated date should be greater than or equal to created date.")
        ;
}
