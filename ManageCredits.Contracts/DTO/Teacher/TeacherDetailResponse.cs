using ManageCredits.Contracts.DTO.Subject;

namespace ManageCredits.Contracts.DTO.Teacher;

public record class TeacherDetailResponse : TeacherResponse
{
  public required ICollection<SubjectDetailResponse> Subjects { get; set; } = [];
}
