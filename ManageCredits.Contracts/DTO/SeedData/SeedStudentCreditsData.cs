using ManageCredits.Domain.Entities;

namespace ManageCredits.Contracts.DTO.SeedData;

public class SeedStudentCreditsData
{
  public required ISeedDataCollection<TeacherEntity, TeacherEntity> Teachers { get; set; }
  public required ISeedDataCollection<Guid, StudentEntity> Students { get; set; }
  public required ISeedDataCollection<SubjectEntity, SubjectEntity> Subjects { get; set; }
}
