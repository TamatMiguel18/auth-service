using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Surname { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Password { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public bool Status { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    // Propiedades de navegación para EF Core
    public UserProfile? UserProfile { get; set; }
    public UserEmail? UserEmail { get; set; }
    public UserPasswordReset? UserPasswordReset { get; set; }
    public Collection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
}
