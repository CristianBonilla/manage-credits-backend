using ManageCredits.Domain.Entities.Base;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.Entities.Details;

public class StudentDetailEntity : BaseEntity
{
  public Guid StudentDetailId { get; set; }
  public required Guid TeacherDetailId { get; set; }
  public required Guid StudentId { get; set; }
  public required Guid ClassId { get; set; }
  public required ClassStatus Status { get; set; }
  public TeacherDetailEntity TeacherDetail { get; set; } = null!;
  public StudentEntity Student { get; set; } = null!;
  public ClassEntity Class { get; set; } = null!;
}
