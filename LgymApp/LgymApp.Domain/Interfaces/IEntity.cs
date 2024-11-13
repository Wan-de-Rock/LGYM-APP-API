namespace LgymApp.Domain.Interfaces;

public interface IEntity
{
    public Guid Id { get; }
    public bool IsDeleted { get; }

    public void SetDeleted(bool deleted = true);
}
