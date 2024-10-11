using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_dotnet;
[Table("permission")]
public class PermissionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<RoleEntity> RoleEntities { get; set; } = new List<RoleEntity>();
    public DateTimeOffset CreateAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}
