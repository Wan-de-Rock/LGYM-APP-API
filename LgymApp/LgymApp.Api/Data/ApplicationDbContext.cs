using LgymApp.Domain.Entities;
using LgymApp.Domain.Helpers;
using LgymApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypes = ReflectionHelper.GetTypesAssignableFromType<IEntity>()
            .Where(type => type.IsClass && !type.IsAbstract);

        foreach (var entityType in entityTypes)
            modelBuilder.Entity(entityType);

        base.OnModelCreating(modelBuilder);
    }
}
