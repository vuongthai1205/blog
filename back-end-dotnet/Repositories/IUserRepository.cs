namespace back_end_dotnet;

public interface IUserRepository
{
    Task<List<UserEntity>> GetAllAsync();
    Task<UserEntity> CreateUser(UserEntity userEntity);
    Task<UserEntity> GetUserEntity(int id);
    Task<UserEntity> GetUserEntityByUsername(string username);
    Task<bool> DeleteUser(UserEntity userEntity);
    Task<bool> UpdateUser(UserEntity userEntity);
}
