namespace ManageCredits.Contracts.DTO.Subject;

public record class SubjectResponse : BaseObject
{
  public Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
}
