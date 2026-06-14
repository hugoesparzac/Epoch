using System.ComponentModel.DataAnnotations;

namespace Epoch.Api.DTOs.Users;

public record LoginRequestDto(
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress]
    string Email,

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    string Password
);