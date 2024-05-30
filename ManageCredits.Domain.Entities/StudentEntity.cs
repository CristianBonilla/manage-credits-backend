using ManageCredits.Domain.Entities.Base;

namespace ManageCredits.Domain.Entities;

public class StudentEntity : BaseEntity
{
  public Guid StudentId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Email { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
}
