namespace LgymApp.Domain.Interfaces;

public interface IEntity
{
    public Guid Id { get; }
    public bool IsDeleted { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public void SetDeleted(bool deleted = true);
}
