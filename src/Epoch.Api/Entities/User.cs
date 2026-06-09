using System.ComponentModel.DataAnnotations;

namespace Epoch.Api.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string NormalizedUsername { get; set; }
    public required string Email { get; set; }
    public required string NormalizedEmail { get; set; }
    public required string PasswordHash { get; set; }
    public required string PreferredTimeZone { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Event> Events { get; set; } = new List<Event>();
}