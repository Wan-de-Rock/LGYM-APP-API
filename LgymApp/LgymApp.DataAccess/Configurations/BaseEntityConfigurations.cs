using LgymApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using LgymApp.DataAccess.ValueGenerators;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<UUIDv7Generator>();

        if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
        {
            builder
                .Property(e => ((ISoftDeletable)e).DeletedAt)
                .HasDefaultValue(null);

            builder.HasQueryFilter(e => !((ISoftDeletable)e).DeletedAt.HasValue);
        }
    }
}

