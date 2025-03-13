using LgymApp.Domain.Interfaces;

namespace LgymApp.Domain.Common;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; } 

}