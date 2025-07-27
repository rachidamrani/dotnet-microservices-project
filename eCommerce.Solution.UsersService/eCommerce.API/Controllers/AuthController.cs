using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUsersService usersService) : ControllerBase
{
    [HttpPost("register")] // POST api/auth/register
    public async Task<IActionResult> Register([FromBody] RegisterRequest? request)
    {
        if (request == null)
            return BadRequest("Invalid registration");

        AuthenticationResponse? registerResponse = await usersService.Register(request);

        if (registerResponse == null || registerResponse.Success == false)
            return BadRequest(registerResponse);

        return Ok(registerResponse);
    }

    [HttpPost("login")] // POST api/auth/login
    public async Task<IActionResult> Login([FromBody] LoginRequest? request)
    {
        if (request == null)
            return BadRequest("Invalid login request");

        AuthenticationResponse? loginResponse = await usersService.Login(request);

        if (loginResponse == null || loginResponse.Success == false)
            return Unauthorized(loginResponse);

        return Ok(loginResponse);
    }
}