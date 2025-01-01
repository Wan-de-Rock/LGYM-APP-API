using LgymApp.Domain.Common;
using LgymApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LgymApp.DataAccess.Interceptors;

public class AuditableObjectsSaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChanges(eventData, result);

        SetAuditableData(context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        SetAuditableData(context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void SetAuditableData(DbContext context)
    {
        //context.ChangeTracker.DetectChanges();

        var entries = context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(e => e.CreatedAt).CurrentValue = DateTime.UtcNow.RemoveMilliSeconds();
                    entry.Property(e => e.CreatedBy).CurrentValue = Guid.NewGuid(); // TODO: set the current user ID
                }

                entry.Property(e => e.UpdatedAt).CurrentValue = DateTime.UtcNow.RemoveMilliSeconds();
                entry.Property(e => e.UpdatedBy).CurrentValue = Guid.NewGuid(); // TODO: set the current user ID
            }
        }
    }
}
