using LgymApp.DataAccess.Converters;
using LgymApp.DataAccess.Interceptors;
using LgymApp.Domain.Attributes;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // private readonly AuditableObjectsSaveChangesInterceptor _auditingInterceptor = new();
    //
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder
    //         .AddInterceptors(_auditingInterceptor)
    //         ;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        NullableUtcDateTimeTruncateConverter dateTimeConverter = null!;
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var dateTimeProperties = entityType.GetProperties().Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)); //TODO check nullable datetime
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
}