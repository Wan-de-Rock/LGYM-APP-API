using LgymApp.Domain.Common;
using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

#region base entity configuration

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAt).HasConversion(
            v => v,
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        ).IsRequired();
        builder.Property(e => e.UpdatedAt).HasConversion(
            v => v,
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        ).IsRequired();
    }
}

public abstract class AuditableEntityConfiguration<T> : BaseEntityConfiguration<T> where T : AuditableEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
    }
}

#endregion

public class UsersConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
    }
}

public class ExercisesConfiguration : AuditableEntityConfiguration<Exercise>
{
    public override void Configure(EntityTypeBuilder<Exercise> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.User);
    }
}

public class PlansConfiguration : AuditableEntityConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(p => p.User)
            ;

        builder.HasMany(p => p.TrainingsDaysPlans)
            .WithOne(t => t.Plan);
    }
}

public class BodyPartMeasurementsConfiguration : AuditableEntityConfiguration<BodyPartMeasurement>
{
    public override void Configure(EntityTypeBuilder<BodyPartMeasurement> builder)
    {
        base.Configure(builder);

        builder.HasOne(b => b.User);
    }
}

public class ExerciseScoresConfiguration : AuditableEntityConfiguration<ExerciseScore>
{
    public override void Configure(EntityTypeBuilder<ExerciseScore> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.User);
        builder.HasOne(e => e.Exercise);
        builder.HasOne(e => e.Training);
    }
}

public class TrainingResultsConfiguration : AuditableEntityConfiguration<TrainingResult>
{
    public override void Configure(EntityTypeBuilder<TrainingResult> builder)
    {
        base.Configure(builder);

        builder.HasOne(t => t.User);
        builder.HasOne(t => t.TrainingPlan);
        builder
            .HasMany(t => t.ExercisesScores)
            .WithOne(e => e.Training);
    }
}

public class TrainingPlansConfiguration : AuditableEntityConfiguration<TrainingPlan>
{
    public override void Configure(EntityTypeBuilder<TrainingPlan> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(p => p.Plan)
            .WithMany(p => p.TrainingsDaysPlans);

        builder.HasMany(p => p.RecommendedNumberOfReps);
    }
}

public class RecommendedNumberOfRepsConfiguration : AuditableEntityConfiguration<RecommendedNumberOfReps>
{
    public override void Configure(EntityTypeBuilder<RecommendedNumberOfReps> builder)
    {
        base.Configure(builder);
        builder.HasOne(r => r.Exercise);
    }
}

public class MainRecordsConfiguration : AuditableEntityConfiguration<MainRecord>
{
    public override void Configure(EntityTypeBuilder<MainRecord> builder)
    {
        base.Configure(builder);
        builder.HasOne(r => r.User);
        builder.HasOne(r => r.Exercise);
    }
}
