using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Common;

[Index(nameof(Id), IsUnique = true)]
public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; } = DateTime.UtcNow;

    public void SetDeleted(bool deleted = true) => IsDeleted = deleted;

    public void SetUpdateAt(DateTime updateAt) =>
        UpdatedAt = updateAt >= UpdatedAt
        ? updateAt
        : throw new ArgumentOutOfRangeException(nameof(updateAt));
}
