namespace ManageCredits.Contracts.DTO.Class;

public record class ClassRequest
{
  public required Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
}
