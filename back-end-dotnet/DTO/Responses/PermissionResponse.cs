namespace back_end_dotnet;

public class PermissionResponse
{
    public int PermissionId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
