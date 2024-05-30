namespace ManageCredits.Domain.Entities.Base;

public abstract class BaseEntity
{
  public DateTimeOffset Created { get; set; }
  public byte[] Version { get; set; } = null!;
}
