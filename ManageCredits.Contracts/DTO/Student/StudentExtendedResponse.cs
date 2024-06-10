namespace ManageCredits.Contracts.DTO.Student;

public record class StudentExtendedResponse : StudentResponse
{
  public ICollection<StudentDetailResponse> Details { get; set; } = [];
}
