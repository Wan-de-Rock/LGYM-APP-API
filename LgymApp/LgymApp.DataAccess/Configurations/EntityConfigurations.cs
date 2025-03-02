using LgymApp.Domain.Entities;
using LgymApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

#region base entity configuration

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .ValueGeneratedNever();

        if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
        {
            builder
                .Property(e => ((ISoftDeletable)e).DeletedAt)
                .HasDefaultValue(null);

            builder.HasQueryFilter(e => !((ISoftDeletable)e).DeletedAt.HasValue);
        }
    }
}

#endregion

public class UsersConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
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

public class ExercisesConfiguration : BaseEntityConfiguration<Exercise>
{
    public override void Configure(EntityTypeBuilder<Exercise> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.User);
    }
}

public class PlansConfiguration : BaseEntityConfiguration<Plan>
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

public class BodyPartMeasurementsConfiguration : BaseEntityConfiguration<BodyPartMeasurement>
{
    public override void Configure(EntityTypeBuilder<BodyPartMeasurement> builder)
    {
        base.Configure(builder);

        builder.HasOne(b => b.User);
    }
}

public class ExerciseScoresConfiguration : BaseEntityConfiguration<ExerciseScore>
{
    public override void Configure(EntityTypeBuilder<ExerciseScore> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.User);
        builder.HasOne(e => e.Exercise);
        builder.HasOne(e => e.Training);
    }
}

public class TrainingResultsConfiguration : BaseEntityConfiguration<TrainingResult>
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

public class TrainingPlansConfiguration : BaseEntityConfiguration<TrainingPlan>
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

public class RecommendedNumberOfRepsConfiguration : BaseEntityConfiguration<RecommendedNumberOfReps>
{
    public override void Configure(EntityTypeBuilder<RecommendedNumberOfReps> builder)
    {
        base.Configure(builder);
        builder.HasOne(r => r.Exercise);
    }
}

public class MainRecordsConfiguration : BaseEntityConfiguration<MainRecord>
{
    public override void Configure(EntityTypeBuilder<MainRecord> builder)
    {
        base.Configure(builder);
        builder.HasOne(r => r.User);
        builder.HasOne(r => r.Exercise);
    }
}
