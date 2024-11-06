using Microsoft.EntityFrameworkCore;

namespace back_end_dotnet;

public class DbBlogContext : DbContext
{
    public DbSet<PermissionEntity> PermissionEntities { get; set; }
    public DbSet<PostEntity> PostEntities { get; set; }
    public DbSet<RoleEntity> RoleEntities { get; set; }
    public DbSet<RolePermissionEntity> RolePermissionEntities { get; set; }
    public DbSet<RoleUserEntity> RoleUserEntities { get; set; }
    public DbSet<UserEntity> UserEntities { get; set; }
    public DbBlogContext(DbContextOptions<DbBlogContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(e => e.RoleEntities)
            .WithMany(e => e.UserEntities)
            .UsingEntity<RoleUserEntity>();

        modelBuilder.Entity<PermissionEntity>()
            .HasMany(e => e.RoleEntities)
            .WithMany(e => e.PermissionEntities)
            .UsingEntity<RolePermissionEntity>();
    }
}
