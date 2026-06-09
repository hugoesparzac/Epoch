using System.ComponentModel.DataAnnotations;

namespace Epoch.Api.DTOs.Events;

public record CreateEventRequest(
    [Required(ErrorMessage = "El título es obligatorio.")]
    [MaxLength(255)]
    string Title,

    [MaxLength(2000)]
    string? Description,

    [Required]
    DateTime StartTimeUtc,

    [Range(1, 10080, ErrorMessage = "La duración debe estar entre 1 minuto y 1 semana.")]
    int DurationInMinutes
);