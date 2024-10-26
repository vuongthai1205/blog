namespace back_end_dotnet;

public interface IRepository<T>
{
    public Task<T> Create(T entity);
    public Task<bool> Update(T entity);
    public Task<List<T>> GetAll();
    public Task<bool> Delete(T entity);
    public Task<T> Get(int id);
}
