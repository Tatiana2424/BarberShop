using BarberShop.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Http;
using BarberShop.BLL.Interfaces;
using BarberShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using BarberShop.BLL.DTO;
using AutoMapper;
using BarberShop.DAL.Repositories.Interfaces.Base;
using Microsoft.Extensions.Options;

namespace BarberShop.BLL.Services;

public class AuthenticationService : Interfaces.IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
   
    public AuthenticationService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ClaimsPrincipal> Authenticate(string username, string password)
    {
        // Find user by username
        var user = await _userRepository.GetUserAsync(username);

        if (user == null)
        {
            return null;
        }

        // Verify password
        var passwordHasher = new PasswordHasher<string>();
        var result = passwordHasher.VerifyHashedPassword(null, user.Password, password);

        if (result != PasswordVerificationResult.Success)
        {
            return null;
        }

        // Return ClaimsPrincipal object with user data
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            //new Claim(ClaimTypes.Email, user.Email),
            // new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
           new Claim("user_id", user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        return principal;
    }


    public async Task<User> GetUserByUsernameOrEmail(string username, string email)
    {
         var userByUsername =await _userRepository.GetUserAsync(username);
        if (userByUsername != null)
        {
            return userByUsername;
        }
        //var userByEmail = await _userRepository.GetUserAsync(email);
        var userByEmail = await _userRepository.GetEmailAsync(email);
        if (userByEmail != null)
        {
            return userByEmail;
        }

        return null;
    }

    public async Task<IdentityResult> CreateUser(UserDTO user, string password)
    {
        // Check if user with the same username or email already exists
        var existingUser = await GetUserByUsernameOrEmail(user.Username, user.Email);

        if (existingUser != null)
        {
            return IdentityResult.Failed(new IdentityError
            {
                Code = "DuplicateUser",
                Description = "User with the same username or email already exists."
            });
        }

        // Hash the password and save the user
        var passwordHasher = new PasswordHasher<string>();
        var hashedPassword = passwordHasher.HashPassword(null, password);
        user.Password = hashedPassword;

        var userDto = _mapper.Map<User>(user);
        var result = await _userRepository.CreateUserAsync(userDto);
       
        return result;
    }
}
