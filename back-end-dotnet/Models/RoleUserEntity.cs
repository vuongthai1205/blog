using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_dotnet;
[Table("role_user")]
public class RoleUserEntity : EntityDefault
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleUserId { get; set; }
    public int UserEntityId { get; set; }
    public int RoleEntityId { get; set; }
    public required UserEntity UserEntity { get; set; }
    public required RoleEntity RoleEntity { get; set; }
    public DateTimeOffset CreateAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}
