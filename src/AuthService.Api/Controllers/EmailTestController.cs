using AuthService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailTestController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailTestController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet("send-welcome")]
    public async Task<IActionResult> SendWelcome(string email, string username)
    {
        await _emailService.SendWelcomeAsync(email, username);
        return Ok(new { message = $"Email enviado exitosamente a {email}" });
    }
}
