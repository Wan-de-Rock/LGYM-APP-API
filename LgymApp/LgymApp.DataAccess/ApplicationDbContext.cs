using LgymApp.Domain.Common;
using LgymApp.Domain.Converters;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        var dateTimeConverter = new UtcDateTimeTruncateConverter();
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var dateTimeProperties = entityType.GetProperties().Where(p => p.ClrType == typeof(DateTime));
            foreach (var property in dateTimeProperties)
            {
                property.SetValueConverter(dateTimeConverter);
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess = true)
    {
        ApplyAuditInformation();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default)
    {
        ApplyAuditInformation();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    /// <summary>
    /// Applies audit information to the entities being tracked by the context.
    /// Sets the CreatedAt and CreatedBy properties for newly added entities.
    /// Sets the UpdatedAt and UpdatedBy properties for newly added or modified entities.
    /// </summary>
    private void ApplyAuditInformation()
    {
        var entities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();
        entities.ForEach(e =>
        {
            if (e.Entity is AuditableEntity entity)
            {
                var now = DateTime.UtcNow;
                if (e.State == EntityState.Added)
                {
                    e.Property(nameof(AuditableEntity.CreatedAt)).CurrentValue = now;
                    e.Property(nameof(AuditableEntity.CreatedBy)).CurrentValue = Guid.NewGuid(); // TODO: set the current user ID
                }
                e.Property(nameof(AuditableEntity.UpdatedAt)).CurrentValue = now;
                e.Property(nameof(AuditableEntity.UpdatedBy)).CurrentValue = Guid.NewGuid(); // TODO: set the current user ID
            }
        });
    }
}
