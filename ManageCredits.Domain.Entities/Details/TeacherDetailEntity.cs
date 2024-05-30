using ManageCredits.Domain.Entities.Base;

namespace ManageCredits.Domain.Entities.Details;

public class TeacherDetailEntity : BaseEntity
{
  public Guid TeacherDetailId { get; set; }
  public Guid TeacherId { get; set; }
  public Guid SubjectId { get; set; }
  public required decimal TotalCredits { get; set; }
  public TeacherEntity Teacher { get; set; } = null!;
  public SubjectEntity Subject { get; set; } = null!;
}
