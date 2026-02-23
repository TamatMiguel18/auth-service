using AuthService.Domain.Entitis;
using AuthService.Domain.Interfaces;
using AuthService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    public async Task<Role?> GetByIdAsync(string roleName)
    {
        return await context.Roles
        .Include(r => r.UserRoles)
        .FirstOrDefaultAsync(r => r.Name == roleName);
    }

    public async Task<int> CountUsersByRoleAsync(string roleName)
    {
        return await context.Roles
        .Where(ur => ur.Role.Name == RoleName)
        .CountAsync();
    }

    public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(string roleName)
    {
        return await context.Roles
        .Where(ur => ur.Role.Name == RoleName)
        .Select(ur => ur.User)
        .Include(u => u.Userprofile)
        .Include(u => u.UserEmail)
        .Include(u => u.UserPasswordReset)
        .Include(u => u.UserRoles)
        .ThenInclude(ur => ur.Role)
        .ToListAsync();
        .ContinueWith(t =>(IReadOnlyList<User>))
    }
}
