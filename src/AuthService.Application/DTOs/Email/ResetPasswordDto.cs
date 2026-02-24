using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs.Email;

public class ResetPasswordDto
{
    //Propiedad que representa el email
    [Required(ErrorMessage = "El email es obligatorio")]
    public string Email { get; set; }=string.Empty;

    //Propiedad que representa el token
    [Required(ErrorMessage = "El token es obligatorio")]
    public string Token { get; set; }=string.Empty;

    //Propiedad que representa la contraseña
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Password { get; set; }=string.Empty;

    //Propiedad que representa la confirmacion de la contraseña
    [MinLength(6, ErrorMessage = "La confirmacion de la contraseña debe tener al menos 6 caracteres")]
    [MaxLength(100, ErrorMessage = "La confirmacion de la contraseña debe tener menos de 100 caracteres")]
    [Required(ErrorMessage = "La confirmacion de la contraseña es obligatoria")]
}