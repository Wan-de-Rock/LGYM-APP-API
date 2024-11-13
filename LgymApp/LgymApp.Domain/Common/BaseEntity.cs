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
    /// Marks the entity as deleted or not deleted.
    /// </summary>
    /// <param name="deleted">If set to <c>true</c>, marks the entity as deleted.</param>
    public void SetDeleted(bool deleted = true) => IsDeleted = deleted;
}
