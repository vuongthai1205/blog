namespace back_end_dotnet;

public class RoleRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<int> PermissionsAssign { get; set; }
}
