namespace LgymApp.Domain.Interfaces;

/// <summary>
/// Interface for entities that support soft deletion.
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// Gets the date and time when the entity was deleted.
    /// </summary>
    public DateTime? DeletedAt { get; }
}