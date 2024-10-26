namespace back_end_dotnet;

public interface IRoleRepository
{
    Task<List<RoleEntity>> GetAllAsync();
    Task<RoleEntity> CreateRole(RoleEntity roleEntity);
    Task<RoleEntity> GetRoleEntity(int id);
    Task<bool> DeleteRole(RoleEntity roleEntity);
    Task<bool> UpdateRole(RoleEntity roleEntity);
}
