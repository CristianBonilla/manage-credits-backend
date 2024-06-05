namespace ManageCredits.Contracts.DTO.Student;

public record class StudentRequest
{
  public required string DocumentNumber { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
}
