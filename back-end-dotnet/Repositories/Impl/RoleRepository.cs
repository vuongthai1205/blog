
using Microsoft.EntityFrameworkCore;

namespace back_end_dotnet;

public class RoleRepository : IRoleRepository
{
    private readonly DbBlogContext _dbBlogContext;
    public RoleRepository(DbBlogContext dbBlogContext){
        _dbBlogContext = dbBlogContext;
    }
    public async Task<RoleEntity> CreateRole(RoleEntity roleEntity)
    {
        await _dbBlogContext.RoleEntities.AddAsync(roleEntity);
        await _dbBlogContext.SaveChangesAsync();
        return roleEntity;
    }

    public async Task<bool> DeleteRole(RoleEntity roleEntity)
    {
        _dbBlogContext.RoleEntities.Remove(roleEntity);
        await _dbBlogContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<RoleEntity>> GetAllAsync()
    {
        var roleEntities = await _dbBlogContext.RoleEntities.ToListAsync();
        return roleEntities;
    }

    public async Task<RoleEntity> GetRoleEntity(int id)
    {
        var roleEntity = await _dbBlogContext.RoleEntities.FindAsync(id);
        if (roleEntity == null)
        {
            return null;
        }
        else{
            return roleEntity;
        }
    }

    public async Task<bool> UpdateRole(RoleEntity roleEntity)
    {
        _dbBlogContext.RoleEntities.Update(roleEntity);
        await _dbBlogContext.SaveChangesAsync();
        return true;
    }
}
