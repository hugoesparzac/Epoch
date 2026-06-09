using Epoch.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Epoch.Api.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events", t => 
        {
            t.HasCheckConstraint("CK_Event_Duration", "\"DurationInMinutes\" >= 1 AND \"DurationInMinutes\" <= 10080");
        });
        builder.HasKey(e => e.Id);
        builder.HasOne(e => e.User)
            .WithMany(u => u.Events)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(e => e.Description)
            .HasMaxLength(2000);
        builder.Property(e => e.CreatedAtUtc)
            .HasPrecision(0)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.Status)
            .HasConversion<string>()
            .HasMaxLength(50);
        builder.HasQueryFilter(e => !e.IsDeleted);
        builder.HasIndex(e => new { e.UserId, e.StartTimeUtc, e.EndTimeUtc });
    }
}