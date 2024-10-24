using AutoMapper;

namespace back_end_dotnet;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<UserRequest, UserEntity>();
        CreateMap<UserEntity, UserRequest>();

        CreateMap<UserResponse, UserEntity>();
        CreateMap<UserEntity, UserResponse>();

        CreateMap<RoleEntity, RoleRequest>();
        CreateMap<RoleRequest, RoleEntity>();
        CreateMap<RoleResponse, RoleEntity>();
        CreateMap<RoleEntity, RoleResponse>();
        // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
    }
}
