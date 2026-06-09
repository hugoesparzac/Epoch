using Epoch.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epoch.Api.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.NormalizedEmail)
            .IsUnique();
        builder.HasIndex(e => e.NormalizedUsername)
            .IsUnique();
        builder.Property(e => e.Username)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.NormalizedUsername)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(e => e.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(512);
        builder.Property(e => e.PreferredTimeZone)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(e => e.CreatedAtUtc)
            .HasPrecision(0)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}