namespace Epoch.Api.DTOs.Events;

public record EventResponse(
    Guid Id,
    string Title,
    string? Description,
    DateTime StartTimeUtc,
    DateTime EndTimeUtc,
    int DurationInMinutes,
    string Status
);