namespace AuthService.Application.DTOs.Email;

public class EmailResponseDto
{
    //Propiedad que representa el id
    public bool Success { get; set; }
    //Propiedad que representa el email
    public string Message { get; set; }=string.Empty;
}