namespace ManageCredits.Contracts.DTO;

public abstract record class BaseObject
{
  public DateTimeOffset Created { get; set; }
  public byte[] Version { get; set; } = null!;
}
