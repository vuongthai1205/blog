using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace back_end_dotnet;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(AuthRequest authRequest)
    {
        if (await _authService.Login(authRequest.UserName, authRequest.Password) is not null)
        {
            return Ok(await _authService.Login(authRequest.UserName, authRequest.Password));
        }
        else
        {
            return BadRequest("Invalid username or password.");
        }
    }

    [HttpGet("current-user")]
    [Authorize]
    public async Task<ActionResult> GetCurrentUser()
    {
        string? userId = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userId == null)
        {
            return BadRequest("User ID not found.");
        }

        // Uncomment and use the following line if you need to fetch user details
        // UserEntity userEntity = await _userService.GetUserEntity(userId);

        return Ok(userId);
    }
}
