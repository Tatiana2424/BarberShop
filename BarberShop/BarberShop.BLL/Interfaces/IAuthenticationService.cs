using BarberShop.BLL.DTO;
using BarberShop.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.Interfaces;

public interface IAuthenticationService
{
    // ClaimsPrincipal Authenticate(string username, string password);
    Task<ClaimsPrincipal> Authenticate(string username, string password);

    Task<User> GetUserByUsernameOrEmail(string username, string email);

    Task<IdentityResult> CreateUser(UserDTO user, string password); 
}

