namespace back_end_dotnet;

public interface IRoleService
{
    public Task<RoleEntity> CreateRole(RoleRequest roleRequest);
    public Task<bool> UpdateRole(int id, RoleRequest roleRequest);
    public Task<List<RoleEntity>> GetRoles();
    public Task<bool> DeleteRole(int id);
    public Task<RoleEntity> GetRoleEntity(int id);
}
