using BarberShop.DAL.Entities;
using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.DAL.Repositories.Realizations;

public class UserRepository : IUserRepository
{
    private readonly BarberShopDbContext _dbContext;

    public UserRepository(BarberShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User> GetEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IdentityResult> CreateUserAsync(User user)
    {
        try
        {
            // Add the user to the database
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            return IdentityResult.Failed(new IdentityError
            {
                Code = "CreateUserFailed",
                Description = ex.Message
            });
        }
    }
}