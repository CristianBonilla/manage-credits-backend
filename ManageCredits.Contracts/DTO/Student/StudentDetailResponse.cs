using ManageCredits.Domain.Helpers;

namespace ManageCredits.Contracts.DTO.Student;

public record class StudentDetailResponse : BaseObject
{
  public Guid StudentDetailId { get; set; }
  public required Guid TeacherDetailId { get; set; }
  public required Guid StudentId { get; set; }
  public required Guid ClassId { get; set; }
  public required ClassStatus Status { get; set; }
}
