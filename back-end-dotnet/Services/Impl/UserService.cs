
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace back_end_dotnet;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
    {
        _repository = userRepository;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<UserEntity> AssignRoleForUser(List<int> roles, UserEntity userEntity)
    {
        var rolesAssign = roles;
        foreach (var role in rolesAssign)
        {
            RoleEntity roleEntity = await _roleRepository.GetRoleEntity(role);
            if (roleEntity != null)
            {
                userEntity.RoleEntities.Add(roleEntity);
            }
        }
        return userEntity;
    }

    public async Task<UserEntity> CreateUser(UserRequest userRequest)
    {
        UserEntity userEntity = _mapper.Map<UserEntity>(userRequest);
        if (userRequest.RolesAssign.Count > 0)
        {
            userEntity = await AssignRoleForUser(userRequest.RolesAssign, userEntity);
        }
        PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
        string passwordHash = passwordHasher.HashPassword(userEntity, userEntity.Password);
        userEntity.Password = passwordHash;
        return await _repository.CreateUser(userEntity);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _repository.GetUserEntity(id);
        return await _repository.DeleteUser(user);
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        var userEntities = await _repository.GetAllAsync();
        var userResponses = _mapper.Map<List<UserResponse>>(userEntities);
        return userResponses;
    }

    public async Task<UserEntity> GetUserEntity(int id)
    {
        return await _repository.GetUserEntity(id);
    }

    public async Task<bool> UpdateUser(int id, UserRequest userRequest)
    {
        var user = await _repository.GetUserEntity(id);
        if (user == null)
        {
            return false;
        }
        else
        {
            _mapper.Map(userRequest, user);
            if (userRequest.RolesAssign.Count > 0)
            {
                user = await AssignRoleForUser(userRequest.RolesAssign, user);
            }
            return await _repository.UpdateUser(user);
        }
    }
}
