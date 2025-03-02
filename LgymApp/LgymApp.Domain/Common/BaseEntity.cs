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
}
