
using AutoMapper;

namespace back_end_dotnet;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper; 
    public RoleService(IRoleRepository roleRepository, IMapper mapper){
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<RoleEntity> CreateRole(RoleRequest roleRequest)
    {
        RoleEntity roleEntity = _mapper.Map<RoleEntity>(roleRequest);
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
        return await _roleRepository.UpdateRole(roleEntity);
    }
}
