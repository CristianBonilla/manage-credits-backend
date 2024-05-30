using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.SeedWork.Collections;

namespace ManageCredits.Domain.SeedWork;

public class SeedData : ISeedData
{
  public SeedStudentCreditsData StudentCredits => new()
  {
    Teachers = StudentCreditsCollection.Teachers,
    Students = StudentCreditsCollection.Students,
    Subjects = StudentCreditsCollection.Subjects 
  };
}
