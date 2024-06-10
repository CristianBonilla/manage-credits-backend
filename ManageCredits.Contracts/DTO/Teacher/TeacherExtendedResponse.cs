using ManageCredits.Contracts.DTO.Subject;

namespace ManageCredits.Contracts.DTO.Teacher;

public record class TeacherExtendedResponse : TeacherResponse
{
  public ICollection<SubjectDetailResponse> Subjects { get; set; } = [];
}
