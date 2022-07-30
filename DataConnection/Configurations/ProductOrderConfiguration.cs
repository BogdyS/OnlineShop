using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConnection.Configurations;

public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.ProductCount)
            .IsRequired();

        builder.HasOne(p => p.Order)
            .WithMany(o => o.ProductOrders)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}