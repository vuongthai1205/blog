using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_dotnet;
[Table("role_permission")]
public class RolePermissionEntity : EntityDefault
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RolePermissionId { get; set;}
    public int PermissionEntityId { get; set; }
    public int RoleEntityId { get; set;}
    public required PermissionEntity PermissionEntity { get; set; }
    public required RoleEntity RoleEntity { get; set; }
    public DateTimeOffset CreateAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}
