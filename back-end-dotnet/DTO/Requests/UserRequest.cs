namespace back_end_dotnet;

public class UserRequest
{
    public string UserName { get; set;}
    public string Password { get; set;}
    public List<RoleRequest>? Roles { get; set; } = new List<RoleRequest>();
    public List<int> RolesAssign { get; set; }
}
