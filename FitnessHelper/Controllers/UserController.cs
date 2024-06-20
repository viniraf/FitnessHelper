using FitnessHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FitnessHelper.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    [SwaggerOperation(Tags = ["User"])]
    [HttpPost("register")]
    public IActionResult Register(UserRegisterModel user)
    {
        return Ok("Not implemented");
    }

    [HttpPost("login")]
    public IActionResult Login(UserLoginModel user)
    {
        return Ok("Not implemented");
    }

}
