using ManageCredits.Domain.Entities.Base;

namespace ManageCredits.Domain.Entities;

public class ClassEntity : BaseEntity
{
  public Guid ClassId { get; set; }
  public required Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public SubjectEntity Subject { get; set; } = null!;
}
