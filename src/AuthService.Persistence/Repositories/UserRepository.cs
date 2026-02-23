using AuthService.Application.Services;
using AuthService.Domain.Entitis;
using AuthService.Domain.Interfaces;
using AuthService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    // Metodo para obtener un usuario por su id
    public async Task<User> GetByIdAsync(string id)
    {
        var user = await context.Users
        .Include(u => u.Userprofile)
        .Include(u => u.UserEmail)
        .Include(u => u.UserPasswordReset)
        .Include(u => u.UserRoles)
        .FirstOrDefaultAsync(u => u.Id == id);
        return user ?? throw new Exception("User not found");
    }

    // Metodo para obtener un usuario por su email
    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await context.Users
        .Include(u => u.Userprofile)
        .Include(u => u.UserEmail)
        .Include(u => u.UserPasswordReset)
        .Include(u => u.UserRoles)
        .FirstOrDefaultAsync(u => u.UserEmail.Email == email);
        return user ?? throw new Exception("User not found");
    }

    // Metodo para obtener un usuario por su username
    public async Task<User> GetByUsernameAsync(string username)
    {
        var user = await context.Users
        .Include(u => u.Userprofile)
        .Include(u => u.UserEmail)
        .Include(u => u.UserPasswordReset)
        .Include(u => u.UserRoles)
        .FirstOrDefaultAsync(u => u.Userprofile.Username == username);
        return user ?? throw new Exception("User not found");
    }   

    // Busca un usuario mediante su token de verificacion de correo 
    public async Task<User> GetByVerificationTokenAsync(string token)
    {
        var user = await context.Users
        .Include(u => u.Userprofile)
        .Include(u => u.UserEmail)
        .Include(u => u.UserPasswordReset)
        .Include(u => u.UserRoles)
        .FirstOrDefaultAsync(u => u.UserEmail.VerificationToken == token);
        return user ?? throw new Exception("User not found");
    }

    // Buscar un usuario mediante su token de restablecimiento de contraseña
    public async Task<User?> GetByResetTokenAsync(string token)
    {
        var user = await context.Users
        .Include(u => u.Userprofile)
        .Include(u => u.UserEmail)
        .Include(u => u.UserPasswordReset)
        .Include(u => u.UserRoles)
        .FirstOrDefaultAsync(u => u.UserPasswordReset.ResetToken == token);
    }

    // Crea un nuevo registro de usuario
    public async Task<User> CreateAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    // Actualiza un registro de usuario
    public async Task<User> UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return await GetByIdAsync(user.Id);
    }

    // Elimina un registro de usuario
    public async Task<bool> DeleteAsync(User user)
    {
        var user = await GetByIdAsync(user.Id);
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }

    // Verificar si su email ya esta registrado
    public async Task<bool> IsEmailRegisteredAsync(string email)
    {
        return await context.Users
        .AnyAsync(u => EF.Functions.Like(u.UserEmail.Email, email));
    }

    // Verificar si su username ya esta registrado
    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await context.Users
        .AnyAsync(u => EF.Functions.Like(u.Userprofile.Username, username));
    }

        // Cambia el rol de un usuario: elimina roles previos y asigna uno nuevo
    public async Task UpdateUserRoleAsync(string userId, string roleId)
    {
        var existingRoles = await context.UserRoles
            .Where(ur => ur.UserId == userId)
            .ToListAsync();

        context.UserRoles.RemoveRange(existingRoles);

        var newUserRole = new UserRole
        {
            Id = UuidGenerator.GenerateUserId(),
            UserId = userId,
            RoleId = roleId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.UserRoles.Add(newUserRole);
        await context.SaveChangesAsync();
    }
}