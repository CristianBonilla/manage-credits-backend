namespace ManageCredits.Contracts.DTO.Teacher;

public record class TeacherRequest
{
  public required string DocumentNumber { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
  public required string Profession { get; set; }
}
