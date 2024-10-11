using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_dotnet;

[Table("role")]
public class RoleEntity : EntityDefault
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<UserEntity> UserEntities { get; set; } = new List<UserEntity>();
    public List<PermissionEntity> PermissionEntities { get; set; } = new List<PermissionEntity>();
    public DateTimeOffset CreateAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}
