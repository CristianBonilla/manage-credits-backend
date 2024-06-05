namespace ManageCredits.Contracts.DTO.Subject;

public record class SubjectRequest
{
  public required string Name { get; set; }
  public string? Description { get; set; }
}
