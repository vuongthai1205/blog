using Microsoft.EntityFrameworkCore;

namespace back_end_dotnet;

public static class MyConfigServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(
                 this IServiceCollection services, IConfiguration config)
    {
        return services;
    }

    public static IServiceCollection AddMyDependencyGroup(
         this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();

        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IPermissionService, PermissionService>();

        return services;
    }
}
