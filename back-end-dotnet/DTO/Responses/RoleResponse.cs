namespace back_end_dotnet;

public class RoleResponse
{
    public int RoleId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
