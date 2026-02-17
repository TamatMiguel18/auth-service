// espacio de nombres para las enumeraciones relacionadas con el servicio de autenticación
namespace AuthService.Domain.Enums;

// enumeración para los roles de usuario en el sistema de autenticación
// Admin: tiene todos los permisos y acceso completo al sistema
// User: tiene permisos limitados y acceso restringido a ciertas funcionalidades
// Moderator: tiene permisos para moderar contenido y gestionar usuarios, pero no tiene acceso completo como un Admin
public enum UserRole
{
    Admin = 0,
    User = 1,
    Moderator = 2
}
