using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConnection.Configurations;

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.Property(m => m.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(m => m.Products)
            .WithOne(p => p.Manufacturer);
    }
}