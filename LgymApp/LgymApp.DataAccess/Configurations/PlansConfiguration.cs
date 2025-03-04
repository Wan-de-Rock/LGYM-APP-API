using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class PlansConfiguration : BaseEntityConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(Plan.TableName);
        
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(p => p.NumberOfTrainingDays)
            .IsRequired();
        
        builder
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired();

        builder
            .HasMany(p => p.TrainingsDaysPlans)
            .WithOne(t => t.Plan)
            .HasForeignKey(t => t.PlanId)
            .IsRequired();
    }
}