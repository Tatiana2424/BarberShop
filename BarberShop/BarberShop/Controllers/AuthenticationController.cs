using BarberShop.WebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using BarberShop.BLL.DTO;
using BarberShop.BLL.Interfaces;
using BarberShop.DAL.Entities;
using AutoMapper;

namespace BarberShop.WebApi.Controllers;

public class AuthenticationController : BaseApiController
{
    private readonly BLL.Interfaces.IAuthenticationService _authService;
    private readonly IMapper _mapper;

    public AuthenticationController(BLL.Interfaces.IAuthenticationService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var principal = await _authService.Authenticate(model.Username, model.Password);
        if (principal != null)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok(new { token = "my-token", user = new { username = model.Username } });
        }
        else
        {
            return BadRequest("Invalid username or password");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserDTO model)
    {
        // перевірка, чи існує користувач з таким іменем користувача або електронною адресою
        var existingUser = await _authService.GetUserByUsernameOrEmail(model.Username, model.Email);
        if (existingUser != null)
        {
            return BadRequest("Username or email already exists.");
        }
        var u = model.statusId;
        // перетворення DTO в об'єкт користувача
        var user = new User
        {
            Username = model.Username,
            Email = model.Email,
            Name = model.Name,
            Surname = model.Surname,
            statusId = model.statusId
        };

        // створення користувача
        var userDto = _mapper.Map<UserDTO>(user);
        var result = await _authService.CreateUser(userDto, model.Password);

        if (result.Succeeded)
        {
            // аутентифікація користувача після створення
            var principal = await _authService.Authenticate(model.Username, model.Password);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Ok(new { token = "my-token", user = new { username = model.Username } });
        }
        else
        {
            // повідомлення про невдалу реєстрацію
            return BadRequest(result.Errors);
        }
    }
}
