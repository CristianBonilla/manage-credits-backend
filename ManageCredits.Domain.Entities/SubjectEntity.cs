using ManageCredits.Domain.Entities.Base;

namespace ManageCredits.Domain.Entities;

public class SubjectEntity : BaseEntity
{
  public Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public ICollection<ClassEntity> Classes { get; set; } = [];
}
