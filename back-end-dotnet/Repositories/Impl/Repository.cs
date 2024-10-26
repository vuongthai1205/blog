
using Microsoft.EntityFrameworkCore;

namespace back_end_dotnet;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbBlogContext _dbBlogContext;
    public Repository(DbBlogContext dbBlogContext){
        _dbBlogContext = dbBlogContext;
    }
    public async Task<T> Create(T entity)
    {
        await _dbBlogContext.AddAsync(entity);
        await _dbBlogContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(T entity)
    {
        _dbBlogContext.Set<T>().Remove(entity);
        await _dbBlogContext.SaveChangesAsync();
        return true;
    }

    public async Task<T> Get(int id)
    {
        var entity = await _dbBlogContext.FindAsync<T>(id);
        if (entity == null)
        {
            return null;
        }
        else{
            return entity;
        }
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbBlogContext.Set<T>().ToListAsync();
    }

    public async Task<bool> Update(T entity)
    {
        _dbBlogContext.Set<T>().Update(entity);
        await _dbBlogContext.SaveChangesAsync();
        return true;
    }
}
