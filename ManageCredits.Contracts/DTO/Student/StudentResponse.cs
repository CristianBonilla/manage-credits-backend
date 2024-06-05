namespace ManageCredits.Contracts.DTO.Student;

public record class StudentResponse : BaseObject
{
  public Guid StudentId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
}
