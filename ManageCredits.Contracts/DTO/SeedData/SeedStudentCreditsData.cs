using ManageCredits.Domain.Entities;

namespace ManageCredits.Contracts.DTO.SeedData;

public class SeedStudentCreditsData
{
  public required ISeedDataCollection<Guid, TeacherEntity> Teachers { get; set; }
  public required ISeedDataCollection<Guid, StudentEntity> Students { get; set; }
  public required ISeedDataCollection<Guid, SubjectEntity> Subjects { get; set; }
  public required ISeedDataCollection<Guid, ClassEntity> Classes { get; set; }
}
