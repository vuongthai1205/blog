
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_dotnet;
[Table("post")]
public class PostEntity : EntityDefault
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Description { get; set; }
    public UserEntity UserEntity { get; set; } = null;
    public int UserEntityId { get; set; }
    public DateTimeOffset CreateAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}
