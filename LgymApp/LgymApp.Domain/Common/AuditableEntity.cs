namespace LgymApp.Domain.Common;

/// <summary>
/// Represents an entity that includes audit information such as creation and modification user.
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    /// <summary>
    /// Gets the identifier of the user who created the entity.
    /// </summary>
    public Guid CreatedBy { get; private set; }

    /// <summary>
    /// Gets the identifier of the user who last updated the entity.
    /// </summary>
    public Guid UpdatedBy { get; private set; }

    public void SetCreatedBy(Guid createdBy) => CreatedBy = createdBy;

    public void SetUpdatedBy(Guid updatedBy) => UpdatedBy = updatedBy;
}

