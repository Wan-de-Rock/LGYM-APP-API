using LgymApp.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace LgymApp.DataAccess.Conventions;

public class SnakeCaseConventionPlugin : IConventionSetPlugin
{
    public ConventionSet ModifyConventions(ConventionSet conventionSet)
    {
        foreach (var entityType in conventionSet.EntityTypeAddedConventions)
        {
            //entityType.ProcessEntityTypeAdded(new SnakeCaseTableNameConvention(), null);
        }

        foreach (var property in conventionSet.PropertyAddedConventions)
        {
            //property.Add(new SnakeCaseColumnNameConvention());
        }

        return conventionSet;
    }
}

public class SnakeCaseTableNameConvention : IEntityTypeAddedConvention
{
    public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
    {
        var tableName = entityTypeBuilder.Metadata.GetTableName();
        if (!string.IsNullOrEmpty(tableName))
        {
            entityTypeBuilder.ToTable(tableName.ToSnakeCase());
        }
    }
}

public class SnakeCaseColumnNameConvention : IPropertyAddedConvention
{
    public void ProcessPropertyAdded(IConventionPropertyBuilder propertyBuilder, IConventionContext<IConventionPropertyBuilder> context)
    {
        var columnName = propertyBuilder.Metadata.GetColumnName(StoreObjectIdentifier.Table(propertyBuilder.Metadata.DeclaringType.GetTableName()));
        if (!string.IsNullOrEmpty(columnName))
        {
            propertyBuilder.HasColumnName(columnName.ToSnakeCase());
        }
    }
}
