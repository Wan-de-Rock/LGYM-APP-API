using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class ExerciseScoresConfiguration : BaseEntityConfiguration<ExerciseScore>
{
    public override void Configure(EntityTypeBuilder<ExerciseScore> builder)
    {
        base.Configure(builder);

        builder.ToTable(ExerciseScore.TableName);
        
        builder
            .Property(e => e.Repeats)
            .IsRequired();
        
        builder
            .Property(e => e.Series)
            .IsRequired();
        
        builder
            .Property(e => e.Weight)
            .IsRequired();
        
        builder
            .Property(e => e.WeightUnit)
            .IsRequired();
      
        builder
            .HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        
        builder
            .HasOne(e => e.Exercise)
            .WithMany()
            .HasForeignKey(e => e.ExerciseId)
            .IsRequired();
        
        builder
            .HasOne(e => e.TrainingResult)
            .WithMany()
            .HasForeignKey(e => e.TrainingResultId)
            .IsRequired();
    }
}