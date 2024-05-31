using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Contracts.DTO.SeedData;

public class SeedStudentCreditsData
{
  public required SeedDataCollection<TeacherEntity> Teachers { get; set; }
  public required SeedDataCollection<StudentEntity> Students { get; set; }
  public required SeedDataCollection<SubjectEntity> Subjects { get; set; }
}
