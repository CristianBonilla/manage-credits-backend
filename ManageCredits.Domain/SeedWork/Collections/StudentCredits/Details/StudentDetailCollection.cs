using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits.Details;

class StudentDetailCollection : SeedDataCollection<StudentDetailEntity>
{
  static readonly TeacherDetailCollection _teacherDetails = StudentCreditsCollection.TeacherDetails;
  static readonly ClassCollection _classes = StudentCreditsCollection.Classes;

  protected override StudentDetailEntity[] Collection => [
    new StudentDetailEntity
    {
      StudentDetailId = new("{11ab0e13-3a0a-4fd7-9f80-3dc89b181efb}"),
      TeacherDetailId = _teacherDetails[0].TeacherDetailId,
      ClassId = _classes[0].ClassId,
      Status = ClassStatus.Completed,
      Created = new DateTimeOffset(2024, 3, 2, 1, 0, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{2096ecba-29db-49d6-9646-a6c3e424953f}"),
      TeacherDetailId = _teacherDetails[0].TeacherDetailId,
      ClassId = _classes[1].ClassId,
      Status = ClassStatus.Completed,
      Created = new DateTimeOffset(2024, 3, 3, 2, 1, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{eab71419-9084-4e72-9558-ce4d76f0fd30}"),
      TeacherDetailId = _teacherDetails[0].TeacherDetailId,
      ClassId = _classes[2].ClassId,
      Status = ClassStatus.Completed,
      Created = new DateTimeOffset(2024, 3, 4, 3, 2, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{90812e38-67ad-4207-8017-e2b09231231e}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      ClassId = _classes[3].ClassId,
      Status = ClassStatus.InProgress,
      Created = new DateTimeOffset(2024, 3, 2, 1, 0, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{6647c961-57b7-4e04-ad8f-3213a6b85f89}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      ClassId = _classes[4].ClassId,
      Status = ClassStatus.Completed,
      Created = new DateTimeOffset(2024, 3, 3, 2, 1, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{7f8a160f-b415-486d-bce2-af44c58af36c}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      ClassId = _classes[5].ClassId,
      Status = ClassStatus.InProgress,
      Created = new DateTimeOffset(2024, 3, 4, 3, 2, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{fa2a8cc5-c7ae-4577-a981-3d4ab4a2ef1b}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      ClassId = _classes[6].ClassId,
      Status = ClassStatus.InProgress,
      Created = new DateTimeOffset(2024, 3, 5, 4, 3, 0, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{58696965-ccef-46b8-b791-74c4f8c28f25}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      ClassId = _classes[7].ClassId,
      Status = ClassStatus.Pending,
      Created = new DateTimeOffset(2024, 3, 6, 5, 4, 0, TimeSpan.Zero)
    }
  ];

  public StudentDetailCollection() : base(8) { }
}
