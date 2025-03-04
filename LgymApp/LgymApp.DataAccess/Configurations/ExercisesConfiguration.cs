using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class ExercisesConfiguration : BaseEntityConfiguration<Exercise>
{
    public override void Configure(EntityTypeBuilder<Exercise> builder)
    {
        base.Configure(builder);

        builder.ToTable(Exercise.TableName);

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(e => e.BodyPart) // TODO: convert to postgres enums 
            .IsRequired();
        
        builder
            .Property(e => e.Description)
            .HasMaxLength(1024);
        
        builder.HasOne(e => e.User);
    }
}