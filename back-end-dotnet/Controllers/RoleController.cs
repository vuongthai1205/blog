using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace back_end_dotnet;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;
    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoleResponse>>> GetAll()
    {
        List<RoleEntity> roleEntities = await _roleService.GetRoles();
        if (roleEntities.Count == 0)
        {
            return NoContent();
        }
        else
        {
            return Ok(_mapper.Map<List<RoleEntity>>(roleEntities));
        }
    }
    [HttpPost]
    public async Task<ActionResult> Create(RoleRequest roleRequest)
    {
        RoleEntity roleEntity = await _roleService.CreateRole(roleRequest);
        if (roleEntity == null)
        {
            return BadRequest();
        }
        else
        {
            return Created();
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, RoleRequest roleRequest)
    {
        if (await _roleService.UpdateRole(id, roleRequest))
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (await _roleService.DeleteRole(id))
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<RoleResponse>> Get(int id)
    {
        RoleEntity roleEntity = await _roleService.GetRoleEntity(id);
        if (roleEntity == null){
            return BadRequest();
        }
        return Ok(_mapper.Map<RoleResponse>(roleEntity)); 
    }
}
