using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits.Details;

class TeacherDetailCollection : SeedDataCollection<TeacherDetailEntity>
{
  const decimal TOTAL_CREDITS = 3.0M;
  static readonly TeacherCollection _teachers = StudentCreditsCollection.Teachers;
  static readonly SubjectCollection _subjects = StudentCreditsCollection.Subjects;

  protected override TeacherDetailEntity[] Collection => [
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{f87b9e01-7066-4a18-bbe5-560a9c6ddec2}"),
      TeacherId = _teachers[0].TeacherId,
      SubjectId = _subjects[0].SubjectId,
      TotalCredits = TOTAL_CREDITS,
      Created = new DateTimeOffset(2024, 2, 2, 1, 0, 0, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{f79f1e3c-8974-4b38-8f9d-72e738efb046}"),
      TeacherId = _teachers[0].TeacherId,
      SubjectId = _subjects[1].SubjectId,
      TotalCredits = TOTAL_CREDITS,
      Created = new DateTimeOffset(2024, 2, 3, 2, 1, 0, TimeSpan.Zero)
    }
  ];

  public TeacherDetailCollection() : base(2) { }
}
