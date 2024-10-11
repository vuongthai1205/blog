
using AutoMapper;

namespace back_end_dotnet;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _repository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserEntity> CreateUser(UserRequest userRequest)
    {
        UserEntity userEntity = _mapper.Map<UserEntity>(userRequest);
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
        else{
            _mapper.Map(userRequest, user);

            return await _repository.UpdateUser(user);
        }
    }
}
