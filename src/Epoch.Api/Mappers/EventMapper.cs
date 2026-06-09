using Epoch.Api.DTOs.Events;
using Epoch.Api.Entities;

namespace Epoch.Api.Mappers;

public static class EventMapper
{
    public static EventResponse ToResponse(this Event e)
    {
        return new EventResponse(
            Id: e.Id,
            Title: e.Title,
            Description: e.Description,
            StartTimeUtc: e.StartTimeUtc,
            EndTimeUtc: e.EndTimeUtc,
            DurationInMinutes: e.DurationInMinutes,
            Status: e.Status.ToString()
        );
    }
    
    public static Event ToEntity(this CreateEventRequest request, Guid userId)
    {
        return new Event
        {
            Title = request.Title,
            Description = request.Description,
            StartTimeUtc = request.StartTimeUtc,
            DurationInMinutes = request.DurationInMinutes,
            UserId = userId,
            Status = EventStatus.Pending,
        };
    }
}