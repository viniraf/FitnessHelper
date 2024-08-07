﻿namespace FitnessHelper.Controllers;

[Route("api/user")]
[SwaggerControllerOrder(1)]
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
    public async Task<IActionResult> Register(UserRegisterModel user)
    {
        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest();
        }

        await _userService.RegisterAsync(user);

        return Created();
    }

    [SwaggerOperation(Tags = ["User"])]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginModel userLogin)
    {
        if (string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
        {
            return BadRequest();
        }

        LoginResult loginResult = await _userService.LoginAsync(userLogin);

        if (loginResult == LoginResult.InvalidCredentials)
        {
            return Unauthorized();
        }

        UserModel userModel = await _userService.GetByUsernameAsync(userLogin.Username);
        int userId = userModel.Id;

        string token = _userService.GenerateToken(userId);

        return Ok($"Token: {token}");
    }

}