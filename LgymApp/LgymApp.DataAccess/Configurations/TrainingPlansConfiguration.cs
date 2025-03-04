using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class TrainingPlansConfiguration : BaseEntityConfiguration<TrainingPlan>
{
    public override void Configure(EntityTypeBuilder<TrainingPlan> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(TrainingPlan.TableName);
        
        builder
            .Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .HasOne(p => p.Plan)
            .WithMany(p => p.TrainingsDaysPlans)
            .HasForeignKey(p => p.PlanId)
            .IsRequired();

        builder
            .HasMany(p => p.RecommendedNumberOfReps)
            .WithOne()
            .IsRequired()
            ;
    }
}