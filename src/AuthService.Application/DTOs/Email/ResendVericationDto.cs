using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs.Email;
//Clase que representa el dto para reenviar la verificacion de correo
public class ResendVericationDto
{
    //Propiedad que representa el email
    [Required(ErrorMessage = "El email es obligatorio")]
    //Validacion que el email sea un email valido
    public string Email { get; set; }=string.Empty;
}