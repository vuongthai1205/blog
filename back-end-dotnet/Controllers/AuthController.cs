
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace back_end_dotnet;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(AuthRequest authRequest)
    {
        if (await _authService.Login(authRequest.UserName, authRequest.Password))
        {
            return Ok();
        }
        else{
            return BadRequest("");
        }

    }
}
