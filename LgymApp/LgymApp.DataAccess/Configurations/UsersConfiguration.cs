using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class UsersConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(User.TableName);
        
        builder
            .Property(u => u.Nickname)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(u => u.HashedPassword)
            .IsRequired()
            .HasMaxLength(64);
    }
}