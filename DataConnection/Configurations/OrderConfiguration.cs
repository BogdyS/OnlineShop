using DataConnection.Entity;
using DataConnection.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConnection.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(o => o.Status)
            .IsRequired()
            .HasDefaultValue(Statuses.Processing);
        builder.Property(o => o.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(o => o.ProductOrders)
            .WithOne(o => o.Order);
    }
}