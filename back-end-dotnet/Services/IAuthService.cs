namespace back_end_dotnet;

public interface IAuthService
{
    Task<bool> Login(string username, string password);
}
