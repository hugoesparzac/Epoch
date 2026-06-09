using System.ComponentModel.DataAnnotations;

namespace Epoch.Api.DTOs.Users;

public record CreateUserRequest(
    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [MaxLength(50)]
    string Username,
    
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
    string Email,
    
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    string Password,
    
    [Required(ErrorMessage = "La zona horaria es obligatoria.")]
    [MaxLength(255)]
    string PreferredTimeZone
);