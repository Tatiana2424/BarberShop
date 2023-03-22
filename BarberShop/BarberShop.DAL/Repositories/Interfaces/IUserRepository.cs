using BarberShop.DAL.Entities;
using BarberShop.DAL.Repositories.Interfaces.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DAL.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserAsync(string username);

    Task<User> GetEmailAsync(string email);

    Task<IdentityResult> CreateUserAsync(User user);
}
