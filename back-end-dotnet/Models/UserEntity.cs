using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_dotnet;
[Table("user")]
public class UserEntity : EntityDefault
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public ICollection<PostEntity> PostEntities { get; } = new List<PostEntity>();
    public List<RoleEntity> RoleEntities { get; set; } = new List<RoleEntity>();
    public DateTimeOffset CreateAt { get; set; } = default;
    public DateTimeOffset UpdateAt { get; set; } = default;
}
