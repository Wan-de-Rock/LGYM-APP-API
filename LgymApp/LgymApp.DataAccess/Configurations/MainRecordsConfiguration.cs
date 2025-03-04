using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class MainRecordsConfiguration : BaseEntityConfiguration<MainRecord>
{
    public override void Configure(EntityTypeBuilder<MainRecord> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(MainRecord.TableName);
        
        builder
            .Property(m => m.Date)
            .IsRequired();
        
        builder
            .Property(m => m.Weight)
            .IsRequired();
        
        builder
            .Property(m => m.WeightUnit)
            .IsRequired();
        
        builder
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .IsRequired();
        
        builder
            .HasOne(r => r.Exercise)
            .WithOne()
            .HasForeignKey<MainRecord>(r => r.ExerciseId)
            .IsRequired();
    }
}