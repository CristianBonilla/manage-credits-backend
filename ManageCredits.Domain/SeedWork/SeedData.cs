using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.SeedWork.Collections;

namespace ManageCredits.Domain.SeedWork;

public class SeedData : ISeedData
{
  public SeedStudentCreditsData StudentCredits => new()
  {
    Teachers = StudentCreditsCollection.Teachers,
    TeacherDetails = StudentCreditsCollection.TeacherDetails,
    Students = StudentCreditsCollection.Students,
    StudentDetails = StudentCreditsCollection.StudentDetails,
    Subjects = StudentCreditsCollection.Subjects,
    Classes = StudentCreditsCollection.Classes
  };
}
