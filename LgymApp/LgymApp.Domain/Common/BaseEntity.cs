using LgymApp.Domain.Interfaces;

namespace LgymApp.Domain.Common;

public abstract class BaseEntity<T> : IEntity where T : IEntity
{
    public Guid Id { get; } = Guid.NewGuid();

    public static string TableName 
        => throw new ArgumentNullException(nameof(TableName), $"{typeof(T).Name} must define a static TableName property.");
}