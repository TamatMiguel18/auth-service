using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces;

public interface IRoleRepository
{
   Task<Role?> GetRoleByIdAsync(string id);
   Task<int> CountUsersInRoleAsync(string roleId);
   Task<IReadOnlyList<User>> GetUsersByRoleAsync(string roleId);
   Task<IReadOnlyList<string>> GetUserRolesAsync(string userId);
   
}
