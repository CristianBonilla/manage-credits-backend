using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits;

class TeacherCollection : SeedDataCollection<TeacherEntity>
{
  const decimal TOTAL_CREDITS = 3.0M;
  static readonly SubjectCollection _subjects = StudentCreditsCollection.Subjects;

  protected override TeacherEntity[] Collection => [
    new TeacherEntity
    {
      TeacherId = new("{d3e5862d-3c30-4b35-8a0d-4632572aae47}"),
      DocumentNumber = "1023944678",
      Firstname = "Cristian Camilo",
      Lastname = "Bonilla",
      Email = "cristian10camilo95@gmail.com",
      Profession = "Senior Software Developer",
      Details = [
        new TeacherDetailEntity
        {
          TeacherDetailId = new("{f87b9e01-7066-4a18-bbe5-560a9c6ddec2}"),
          SubjectId = _subjects[0].SubjectId,
          TotalCredits = TOTAL_CREDITS
        },
        new TeacherDetailEntity
        {
          TeacherDetailId = new("{f79f1e3c-8974-4b38-8f9d-72e738efb046}"),
          SubjectId = _subjects[1].SubjectId,
          TotalCredits = TOTAL_CREDITS
        }
      ]
    }
  ];

  public TeacherCollection() : base(1) { }
}
