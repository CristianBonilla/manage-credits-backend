namespace ManageCredits.Contracts.DTO.Class;

public record class ClassResponse : BaseObject
{
  public Guid ClassId { get; set; }
  public required Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
}
