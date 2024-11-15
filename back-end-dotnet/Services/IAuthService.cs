namespace back_end_dotnet;

public interface IAuthService
{
    Task<string> Login(string username, string password);
    Task<string> GenerateToken(UserEntity user);
}
