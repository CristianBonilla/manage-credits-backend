using ManageCredits.Contracts.DTO.Student;
using ManageCredits.Contracts.DTO.Subject;
using ManageCredits.Contracts.DTO.Teacher;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Contracts.DTO;

public record class StudentCreditsFilter
{
  public required TeacherResponse Teacher { get; set; }
  public required StudentResponse Student { get; set; }
  public required SubjectResponse Subject { get; set; }
  public required ClassStatus Status { get; set; }
  public required decimal Credits { get; set; }
}
