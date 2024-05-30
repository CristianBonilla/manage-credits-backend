using ManageCredits.Domain.SeedWork.Collections.StudentCredits;

namespace ManageCredits.Domain.SeedWork.Collections;

class StudentCreditsCollection
{
  public static TeacherCollection Teachers => new();
  public static StudentCollection Students => new();
  public static SubjectCollection Subjects => new();
}
