namespace back_end_dotnet;

public interface IPermissionService
{
    public Task<PermissionResponse> CreatePermission(PermissionRequest permissionRequest);
    public Task<List<PermissionResponse>> GetPermissionEntities();
    public Task<PermissionResponse> GetPermissionEntity(int id);
    public Task<bool> UpdatePermission(int id, PermissionRequest permissionRequest);
    public Task<bool> DeletePermission(int id);
}
