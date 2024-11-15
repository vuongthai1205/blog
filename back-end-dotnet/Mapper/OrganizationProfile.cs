using AutoMapper;

namespace back_end_dotnet;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<UserRequest, UserEntity>().ForMember(o => o.RoleEntities, b => b.MapFrom(z => z.Roles));
        CreateMap<UserEntity, UserRequest>().ForMember(o => o.Roles, b => b.MapFrom(z => z.RoleEntities));

        CreateMap<UserResponse, UserEntity>().ForMember(o => o.RoleEntities, b => b.MapFrom(z => z.Roles));
        CreateMap<UserEntity, UserResponse>().ForMember(o => o.Roles, b => b.MapFrom(z => z.RoleEntities));

        CreateMap<RoleEntity, RoleRequest>();
        CreateMap<RoleRequest, RoleEntity>();
        CreateMap<RoleResponse, RoleEntity>().ForMember(o => o.PermissionEntities, b => b.MapFrom(z => z.Permissions));
        CreateMap<RoleEntity, RoleResponse>().ForMember(o => o.Permissions, b => b.MapFrom(z => z.PermissionEntities));

        CreateMap<PermissionEntity, PermissionRequest>();
        CreateMap<PermissionRequest, PermissionEntity>();
        CreateMap<PermissionResponse, PermissionEntity>();
        CreateMap<PermissionEntity, PermissionResponse>();
        // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
    }
}
