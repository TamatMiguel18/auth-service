using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AuthService.Domain.Entities;

public class Role
{
    // Identificador único del rol
    [Key]
    [MaxLength(15)]
    public int Id { get; set; }

    // Nombre del rol (obligatorio)
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    // Descripción del rol (obligatorio)
    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    // Relación con usuarios
    public ICollection<User> Users { get; set; } = new List<User>();
}
