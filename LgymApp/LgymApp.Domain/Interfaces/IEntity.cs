namespace LgymApp.Domain.Interfaces;

public interface IEntity
{
    public Guid Id { get; }

    public static abstract string TableName { get; }
}