using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConnection.Configurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
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