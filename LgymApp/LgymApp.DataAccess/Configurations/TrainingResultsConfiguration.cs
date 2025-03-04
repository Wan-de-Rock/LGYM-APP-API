using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class TrainingResultsConfiguration : BaseEntityConfiguration<TrainingResult>
{
    public override void Configure(EntityTypeBuilder<TrainingResult> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(TrainingResult.TableName);
        
        builder
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .IsRequired();
        
        builder
            .HasOne(t => t.TrainingPlan)
            .WithMany()
            .HasForeignKey(t => t.TrainingPlanId)
            .IsRequired();
        
        builder
            .HasMany(t => t.ExercisesScores)
            .WithOne(e => e.TrainingResult)
            .HasForeignKey(e => e.TrainingResultId)
            .IsRequired();
    }
}