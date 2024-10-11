using Microsoft.AspNetCore.Mvc;

namespace back_end_dotnet;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAllUser()
    {
        return Ok(await _userService.GetAllAsync());
    }
    [HttpPost]
    public async Task<ActionResult<UserEntity>> CreateUser(UserRequest userRequest)
    {
        return Ok(await _userService.CreateUser(userRequest));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> GetUserById(int id)
    {
        var user = await _userService.GetUserEntity(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var isDelete = await _userService.DeleteUser(id);

        if (isDelete)
        {
            return NoContent();
        }
        return BadRequest();

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserEntity>> EditUser(int id, [FromBody] UserRequest userRequest)
    {
        var isUpdate = await _userService.UpdateUser(id, userRequest);
        if (isUpdate)
        {
            return Ok();
        }
        return BadRequest();
    }
}
