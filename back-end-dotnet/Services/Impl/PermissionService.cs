
using AutoMapper;

namespace back_end_dotnet;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IMapper _mapper;
    public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
    {
        _permissionRepository = permissionRepository;
        _mapper = mapper;
    }
    public async Task<PermissionResponse> CreatePermission(PermissionRequest permissionRequest)
    {
        PermissionEntity permissionEntity = _mapper.Map<PermissionEntity>(permissionRequest);
        PermissionEntity permissionEntity1 = await _permissionRepository.Create(permissionEntity);
        if (permissionEntity1 == null)
        {
            return null;
        }
        return _mapper.Map<PermissionResponse>(permissionEntity1);
    }

    public async Task<bool> DeletePermission(int id)
    {
        PermissionEntity permissionEntity = await _permissionRepository.Get(id);
        return await _permissionRepository.Delete(permissionEntity);
    }

    public async Task<List<PermissionResponse>> GetPermissionEntities()
    {
        List<PermissionEntity> permissionEntities = await _permissionRepository.GetAll();

        return _mapper.Map<List<PermissionResponse>>(permissionEntities); 
    }

    public async Task<PermissionResponse> GetPermissionEntity(int id)
    {
        PermissionEntity permissionEntity =  await _permissionRepository.Get(id);
        if (permissionEntity == null){
            return null;
        }
        return _mapper.Map<PermissionResponse>(permissionEntity);
    }

    public async Task<bool> UpdatePermission(int id, PermissionRequest permissionRequest)
    {
        PermissionEntity permission = await _permissionRepository.Get(id);
        _mapper.Map(permissionRequest, permission);
        return await _permissionRepository.Update(permission);
    }
}
