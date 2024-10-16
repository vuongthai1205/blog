
using Microsoft.AspNetCore.Identity;

namespace back_end_dotnet;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    public AuthService(IUserRepository userRepository){
        this._userRepository = userRepository;
    }
    public async Task<bool> Login(string username, string password)
    {
        UserEntity userEntity = await _userRepository.GetUserEntityByUsername(username);
        if (userEntity == null){
            return false;
        }
        else{
            PasswordHasher<UserEntity> passwordHash = new PasswordHasher<UserEntity>();
            PasswordVerificationResult passwordVerificationResult = passwordHash.VerifyHashedPassword(userEntity, userEntity.Password, password);
            return passwordVerificationResult == PasswordVerificationResult.Success ?  true : false;
        }
    }
}
