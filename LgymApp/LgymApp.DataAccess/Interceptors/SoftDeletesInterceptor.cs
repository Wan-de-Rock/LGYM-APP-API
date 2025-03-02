using LgymApp.Domain.Helpers;
using LgymApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LgymApp.DataAccess.Interceptors;

public class SoftDeletesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChanges(eventData, result);

        HandleSoftDeletes(context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        HandleSoftDeletes(context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    
    private void HandleSoftDeletes(DbContext context)
    {
        var entries = context.ChangeTracker.Entries<ISoftDeletable>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Property(nameof(ISoftDeletable.DeletedAt)).CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
