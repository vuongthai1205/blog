
using Microsoft.EntityFrameworkCore;

namespace back_end_dotnet;

public class UserRepository : IUserRepository
{
    private readonly DbBlogContext _blogContext;
    public UserRepository(DbBlogContext blogContext)
    {
        _blogContext = blogContext;
    }
    public async Task<UserEntity> CreateUser(UserEntity userEntity)
    {
        await _blogContext.UserEntities.AddAsync(userEntity);
        await _blogContext.SaveChangesAsync();
        return userEntity;
    }

    public async Task<bool> DeleteUser(UserEntity userEntity)
    {
        try
        {
            _blogContext.UserEntities.Remove(userEntity);
            await _blogContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<List<UserEntity>> GetAllAsync()
    {
        var userEntities = await _blogContext.UserEntities.Include(m => m.RoleEntities).ToListAsync();
        return userEntities;
    }

    public async Task<UserEntity> GetUserEntity(int id)
    {
        var entity = await _blogContext.UserEntities.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async Task<UserEntity> GetUserEntityByUsername(string username)
    {
        var entity = await _blogContext.UserEntities.Where(b => b.Username == username).FirstOrDefaultAsync();
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async Task<bool> UpdateUser(UserEntity userEntity)
    {
        _blogContext.UserEntities.Update(userEntity);
        await _blogContext.SaveChangesAsync();
        return true;
    }
}
