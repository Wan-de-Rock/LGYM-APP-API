using LgymApp.DataAccess.Converters;
using LgymApp.DataAccess.Interceptors;
using LgymApp.Domain.Attributes;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.DataAccess;

public class ApplicationDbContext : DbContext
{
    private readonly AuditableObjectsSaveChangesInterceptor _auditingInterceptor = new();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        //ChangeTracker.StateChanged += SetAuditableData;
        //ChangeTracker.Tracked += SetAuditableData;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .AddInterceptors(_auditingInterceptor)
            ;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        UtcDateTimeTruncateConverter dateTimeConverter = null;
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var dateTimeProperties = entityType.GetProperties().Where(p => p.ClrType == typeof(DateTime)); //TODO handle nullable datetime
            foreach (var property in dateTimeProperties)
            {
                if (property.GetValueConverter() is not null)
                    continue;

                var attribute = property.PropertyInfo?.GetCustomAttributes(typeof(DateTimeDefinitionAttribute), false).OfType<DateTimeDefinitionAttribute>().SingleOrDefault();

                if (attribute is not null)
                    dateTimeConverter = new(attribute.DateTimeComponent, attribute.Kind);
                else
                    dateTimeConverter = new();

                property.SetValueConverter(dateTimeConverter);
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    //[Obsolete]
    //private static void SetAuditableData(object sender, EntityEntryEventArgs e)
    //{
    //    if (e.Entry.Entity is AuditableEntity auditableEntity)
    //    {
    //        switch (e.Entry.State)
    //        {
    //            case EntityState.Added:
    //                auditableEntity.CreatedAt = DateTime.UtcNow.RemoveMilliSeconds();
    //                auditableEntity.CreatedBy = Guid.NewGuid(); // TODO: set the current user ID
    //                auditableEntity.UpdatedAt = DateTime.UtcNow.RemoveMilliSeconds();
    //                auditableEntity.UpdatedBy = Guid.NewGuid(); // TODO: set the current user ID
    //                break;
    //            case EntityState.Modified:
    //                auditableEntity.UpdatedAt = DateTime.UtcNow.RemoveMilliSeconds();
    //                auditableEntity.UpdatedBy = Guid.NewGuid(); // TODO: set the current user ID
    //                break;
    //        }
    //    }
    //}
}