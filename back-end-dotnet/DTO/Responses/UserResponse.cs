namespace back_end_dotnet;

public class UserResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<RoleResponse>? Roles { get; set; }
}
