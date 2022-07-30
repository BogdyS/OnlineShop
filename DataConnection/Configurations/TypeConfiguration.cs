using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = DataConnection.Entity.Type;

namespace DataConnection.Configurations;

public class TypeConfiguration : IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(40);
        builder.Property(t=>t.Parameters)
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        builder.HasMany(t => t.Products)
            .WithOne(t => t.Type);
    }
}