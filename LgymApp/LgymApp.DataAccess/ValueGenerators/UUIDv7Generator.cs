using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace LgymApp.DataAccess.ValueGenerators;

public class UUIDv7Generator : ValueGenerator
{
    public override bool GeneratesTemporaryValues => false;

    protected override object NextValue(EntityEntry entry) => Guid.CreateVersion7();
}
