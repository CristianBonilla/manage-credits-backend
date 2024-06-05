namespace ManageCredits.Contracts.DTO;

public class ServiceError
{
  public ICollection<string> Errors { get; set; } = [];
}
