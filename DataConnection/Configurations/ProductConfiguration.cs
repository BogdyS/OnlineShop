using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConnection.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.Price)
            .IsRequired();
        builder.Property(p => p.Parameters)
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        builder.HasOne(p => p.Type)
            .WithMany(t => t.Products)
            .HasForeignKey(p=>p.TypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.Manufacturer)
            .WithMany(m => m.Products)
            .HasForeignKey(p => p.ManufacturerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.ProductOrders)
            .WithOne(o => o.Product);
    }
}