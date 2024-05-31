using ManageCredits.Domain.SeedWork.Collections.StudentCredits;
using ManageCredits.Domain.SeedWork.Collections.StudentCredits.Details;

namespace ManageCredits.Domain.SeedWork.Collections;

class StudentCreditsCollection
{
  public static TeacherCollection Teachers => new();
  public static TeacherDetailCollection TeacherDetails => new();
  public static StudentCollection Students => new();
  public static StudentDetailCollection StudentDetails => new();
  public static SubjectCollection Subjects => new();
  public static ClassCollection Classes => new();
}
