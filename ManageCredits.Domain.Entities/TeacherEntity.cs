using ManageCredits.Domain.Entities.Base;
using ManageCredits.Domain.Entities.Details;

namespace ManageCredits.Domain.Entities;

public class TeacherEntity : BaseEntity
{
  public Guid TeacherId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Email { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Profession { get; set; }
  public ICollection<TeacherDetailEntity> Details { get; set; } = [];
}
