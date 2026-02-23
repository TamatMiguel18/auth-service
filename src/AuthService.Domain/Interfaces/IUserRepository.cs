using AuthService.Domain.Entitis;

namespace AuthService.Domain.Interfaces;

public interface IUserRepository
{
   // Metodos de consulta
   Task<User?> GetUserByIdAsync(string id);
   Task<User?> GetUserByEmailAsync(string email);
   Task<User?> GetUserByUsernameAsync(string username);
   Task<User?> GetUserByPasswordResetTokenAsync(string passwordResetToken); 
   Task<User?> CreateUserAsync(User user);
   Task<User?> UpdateUserAsync(User user);
   Task<User?> DeleteUserAsync(User user);

   Task<bool> UserExistsByEmailAsync(string email);
   Task<bool> UserExistsByUsernameAsync(string username);

   Task UpdateUserRolesAsync(string userId, string roleId);
}