namespace back_end_dotnet;

public class PermissionRepository : Repository<PermissionEntity>, IPermissionRepository
{
    public PermissionRepository(DbBlogContext dbBlogContext) : base(dbBlogContext)
    {
    }
}
