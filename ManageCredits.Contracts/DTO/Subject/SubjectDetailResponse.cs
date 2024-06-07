namespace ManageCredits.Contracts.DTO.Subject;

public record class SubjectDetailResponse : SubjectResponse
{
  public required decimal TotalCredits { get; set; }
}
