
using AutoMapper;

namespace back_end_dotnet;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IMapper _mapper;
    public RoleService(IRoleRepository roleRepository, IMapper mapper, IPermissionRepository permissionRepository)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
        _permissionRepository = permissionRepository;
    }
    public async Task<RoleEntity> CreateRole(RoleRequest roleRequest)
    {
        RoleEntity roleEntity = _mapper.Map<RoleEntity>(roleRequest);
        if (roleEntity.PermissionEntities.Count > 0)
        {
            roleEntity = await AssignPermissionForRole(roleRequest.PermissionsAssign, roleEntity);
        }
        return await _roleRepository.CreateRole(roleEntity);
    }

    public async Task<bool> DeleteRole(int id)
    {
        RoleEntity roleEntity = await _roleRepository.GetRoleEntity(id);
        return await _roleRepository.DeleteRole(roleEntity);
    }

    public async Task<RoleEntity> GetRoleEntity(int id)
    {
        return await _roleRepository.GetRoleEntity(id);
    }

    public async Task<List<RoleEntity>> GetRoles()
    {
        return await _roleRepository.GetAllAsync();
    }

    public async Task<bool> UpdateRole(int id, RoleRequest roleRequest)
    {
        RoleEntity roleEntity = await _roleRepository.GetRoleEntity(id);
        _mapper.Map(roleRequest, roleEntity);
        if (roleRequest.PermissionsAssign.Count > 0)
        {
            roleEntity = await AssignPermissionForRole(roleRequest.PermissionsAssign, roleEntity);
        }
        return await _roleRepository.UpdateRole(roleEntity);
    }

    public async Task<RoleEntity> AssignPermissionForRole(List<int> permissions, RoleEntity roleEntity)
    {
        var permissionAssign = permissions;
        foreach (var permission in permissionAssign)
        {
            PermissionEntity permissionEntity = await _permissionRepository.Get(permission);
            if (permissionEntity != null)
            {
                roleEntity.PermissionEntities.Add(permissionEntity);
            }
        }
        return roleEntity;
    }
}
