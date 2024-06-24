using FitnessHelper.Models;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FitnessHelper.Enums;
using FitnessHelper.Helpers;
using Microsoft.AspNetCore.Authorization;
using FitnessHelper.Helpers.Implementations;

namespace FitnessHelper.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [SwaggerOperation(Tags = ["User"])]
    [HttpPost("register")]
    public IActionResult Register(UserRegisterModel user)
    {
        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest("The information was not filled in correctly");
        }

        _userService.Register(user);
        return Ok("User created successfully");
    }

    [SwaggerOperation(Tags = ["User"])]
    [HttpPost("login")]
    public IActionResult Login(UserLoginModel user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest("The information was not filled in correctly");
        }

        LoginResult loginResult = _userService.Login(user);

        if (loginResult == LoginResult.UserNotFound)
        {
            return Unauthorized("Invalid credentials");
        }

        if (loginResult == LoginResult.InvalidPassword)
        {
            return Unauthorized("Invalid password");
        }

        string token = _userService.GenerateToken(user.Username);

        return Ok($"Token: {token}");
    }

}
