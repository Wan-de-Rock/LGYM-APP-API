using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LgymApp.DataAccess.Configurations;

public class BodyPartMeasurementsConfiguration : BaseEntityConfiguration<BodyPartMeasurement>
{
    public override void Configure(EntityTypeBuilder<BodyPartMeasurement> builder)
    {
        base.Configure(builder);
        
        builder.ToTable(BodyPartMeasurement.TableName);
        
        builder
            .Property(b => b.BodyPart)
            .IsRequired();
        
        builder
            .Property(b => b.WeightUnit)
            .IsRequired();
        
        builder
            .Property(b => b.Weight)
            .IsRequired();
        
        builder
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .IsRequired();
    }
}