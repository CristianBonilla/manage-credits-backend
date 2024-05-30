using ManageCredits.Domain.Entities.Base;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.Entities.Details;

public class StudentDetailEntity : BaseEntity
{
  public Guid StudentDetailId { get; set; }
  public Guid TeacherDetailId { get; set; }
  public Guid ClassId { get; set; }
  public required decimal Credits { get; set; }
  public ClassStatus Status { get; set; }
  public TeacherDetailEntity TeacherDetail { get; set; } = null!;
  public ClassEntity Class { get; set; } = null!;
}
