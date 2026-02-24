namespace AuthService.Application.Interfaces;

public interface IEmailService
{
    Task SendEmailVerificationAsync(string email, string username, string token);
    Task SendEmailResetAsync(string email, string username, string token);
    Task SendWelcomeAsync(string email, string username);
}

