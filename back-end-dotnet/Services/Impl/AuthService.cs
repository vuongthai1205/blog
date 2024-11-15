
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace back_end_dotnet;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    public AuthService(IUserRepository userRepository, IConfiguration config)
    {
        this._userRepository = userRepository;
        this._config = config;
    }

    public Task<string> GenerateToken(UserEntity user)
    {
        var issuer = _config.GetValue<string>("Jwt:Issuer");
        var audience = _config.GetValue<string>("Jwt:Audience");
        var key = Encoding.UTF8.GetBytes
        (_config.GetValue<string>("Jwt:Key"));
        var authClaims = new List<Claim>
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()),
            };

        foreach (var userRole in user.RoleEntities)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole.Name));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(authClaims),
            Expires = DateTime.UtcNow.AddHours(3),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);

        return Task.FromResult(stringToken);
    }

    public async Task<string> Login(string username, string password)
    {
        UserEntity userEntity = await _userRepository.GetUserEntityByUsername(username);
        if (userEntity == null)
        {
            return null;
        }
        else
        {
            PasswordHasher<UserEntity> passwordHash = new PasswordHasher<UserEntity>();
            PasswordVerificationResult passwordVerificationResult = passwordHash.VerifyHashedPassword(userEntity, userEntity.Password, password);
            string token = await GenerateToken(userEntity);

            return passwordVerificationResult == PasswordVerificationResult.Success ? token : null;
        }
    }
}
