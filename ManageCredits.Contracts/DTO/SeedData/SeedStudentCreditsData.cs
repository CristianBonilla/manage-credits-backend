using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Contracts.DTO.SeedData;

public class SeedStudentCreditsData
{
  public required SeedDataCollection<TeacherEntity> Teachers { get; set; }
  public required SeedDataCollection<TeacherDetailEntity> TeacherDetails { get; set; }
  public required SeedDataCollection<StudentEntity> Students { get; set; }
  public required SeedDataCollection<StudentDetailEntity> StudentDetails { get; set; }
  public required SeedDataCollection<SubjectEntity> Subjects { get; set; }
  public required SeedDataCollection<ClassEntity> Classes { get; set; }
}
