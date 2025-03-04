using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class RecommendedNumberOfRepsConfiguration : BaseEntityConfiguration<RecommendedNumberOfReps>
{
    public override void Configure(EntityTypeBuilder<RecommendedNumberOfReps> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(RecommendedNumberOfReps.TableName);
        
        builder
            .Property(r => r.Series)
            .IsRequired();
        
        builder
            .Property(r => r.Repeats)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasOne(r => r.Exercise)
            .WithOne()
            .HasForeignKey<RecommendedNumberOfReps>(r => r.ExerciseId)
            .IsRequired();
    }
}