using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace back_end_dotnet;

[ApiController]
[Route("[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;
    private readonly IMapper _mapper;
    public PermissionController(IPermissionService permissionService, IMapper mapper)
    {
        _permissionService = permissionService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<PermissionResponse>> CreatePermission(PermissionRequest permissionRequest)
    {
        PermissionResponse permissionEntity = await _permissionService.CreatePermission(permissionRequest);
        if (permissionEntity == null)
        {
            return BadRequest();
        }
        else
        {
            return Ok(permissionEntity);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<PermissionResponse>>> GetPermissions()
    {
        return Ok(await _permissionService.GetPermissionEntities());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PermissionResponse>> GetPermission(int id)
    {
        return Ok(await _permissionService.GetPermissionEntity(id));
    }

    [HttpPut]
    public async Task<ActionResult> UpdatePermission(int id, PermissionRequest permissionRequest)
    {
        if (await _permissionService.UpdatePermission(id, permissionRequest))
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeletePermission(int id)
    {
        if (await _permissionService.DeletePermission(id))
        {
            return NoContent();
        }
        return BadRequest();
    }

}
