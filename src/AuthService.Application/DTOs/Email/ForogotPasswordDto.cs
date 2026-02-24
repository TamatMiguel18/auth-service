using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs.Email;

public class ForogotPasswordDto
{
    //Propiedad que representa el email
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email es invalido")]
    public string Email { get; set; }=string.Empty;
}
