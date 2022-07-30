using DataConnection.Entity;
using DataConnection.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataConnection.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);
        builder.HasIndex(u => u.Email)
            .IsUnique();
        builder.Property(u => u.PasswordHash)
            .IsRequired();
        builder.Property(u => u.Role)
            .IsRequired()
            .HasDefaultValue(Roles.Client);

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .OnDelete(DeleteBehavior.Cascade);
    }
}