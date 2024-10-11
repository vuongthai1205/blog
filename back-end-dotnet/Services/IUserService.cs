namespace back_end_dotnet;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync();
    Task<UserEntity> CreateUser(UserRequest userRequest);
    Task<UserEntity> GetUserEntity(int id);
    Task<bool> DeleteUser(int id);
    Task<bool> UpdateUser(int id, UserRequest userRequest);
}
