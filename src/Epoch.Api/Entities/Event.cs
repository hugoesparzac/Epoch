using System.ComponentModel.DataAnnotations;

namespace Epoch.Api.Entities;

public class Event
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartTimeUtc { get; set; }
    public int DurationInMinutes { get; set; }
    public DateTime EndTimeUtc { get; set; }
    public EventStatus Status { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public bool IsDeleted { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
}