using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits;

class StudentCollection : SeedDataCollection<StudentEntity>
{
  static readonly TeacherCollection _teachers = StudentCreditsCollection.Teachers;
  static readonly SubjectCollection _subjects = StudentCreditsCollection.Subjects;

  protected override StudentEntity[] Collection => [
    new StudentEntity
    {
      StudentId = new("{ee466b07-1d3e-4356-8d03-0067d5ba30e5}"),
      DocumentNumber = "1033671288",
      Firstname = "Angela Natalia",
      Lastname = "Suarez",
      Email = "angela.suarez@outlook.com",
      Details = [
        new StudentDetailEntity
        {
          StudentDetailId = new("{11ab0e13-3a0a-4fd7-9f80-3dc89b181efb}"),
          TeacherDetailId = GetTeacherDetailId(0),
          ClassId = GetSubjectClassId(0, 0),
          Status = ClassStatus.Completed
        },
        new StudentDetailEntity
        {
          StudentDetailId = new("{2096ecba-29db-49d6-9646-a6c3e424953f}"),
          TeacherDetailId = GetTeacherDetailId(0),
          ClassId = GetSubjectClassId(0, 1),
          Status = ClassStatus.Completed
        },
        new StudentDetailEntity
        {
          StudentDetailId = new("{eab71419-9084-4e72-9558-ce4d76f0fd30}"),
          TeacherDetailId = GetTeacherDetailId(0),
          ClassId = GetSubjectClassId(0, 2),
          Status = ClassStatus.Completed
        }
      ]
    },
    new StudentEntity
    {
      StudentId = new("{107e7e52-74fc-4589-b7d9-5f1ffc434637}"),
      DocumentNumber = "1109432112",
      Firstname = "Jeison Andrés",
      Lastname = "Bonilla",
      Email = "jeison.bonilla@gmail.com",
      Details = [
        new StudentDetailEntity
        {
          StudentDetailId = new("{90812e38-67ad-4207-8017-e2b09231231e}"),
          TeacherDetailId = GetTeacherDetailId(1),
          ClassId = GetSubjectClassId(1, 0),
          Status = ClassStatus.InProgress
        },
        new StudentDetailEntity
        {
          StudentDetailId = new("{6647c961-57b7-4e04-ad8f-3213a6b85f89}"),
          TeacherDetailId = GetTeacherDetailId(1),
          ClassId = GetSubjectClassId(1, 1),
          Status = ClassStatus.Completed
        },
        new StudentDetailEntity
        {
          StudentDetailId = new("{7f8a160f-b415-486d-bce2-af44c58af36c}"),
          TeacherDetailId = GetTeacherDetailId(1),
          ClassId = GetSubjectClassId(1, 2),
          Status = ClassStatus.InProgress
        },
        new StudentDetailEntity
        {
          StudentDetailId = new("{fa2a8cc5-c7ae-4577-a981-3d4ab4a2ef1b}"),
          TeacherDetailId = GetTeacherDetailId(1),
          ClassId = GetSubjectClassId(1, 3),
          Status = ClassStatus.InProgress
        },
        new StudentDetailEntity
        {
          StudentDetailId = new("{58696965-ccef-46b8-b791-74c4f8c28f25}"),
          TeacherDetailId = GetTeacherDetailId(1),
          ClassId = GetSubjectClassId(1, 4),
          Status = ClassStatus.Pending
        }
      ]
    }
  ];

  public StudentCollection() : base(2) { }

  private static Guid GetTeacherDetailId(int detailIndex) => _teachers[0].Details.ElementAt(detailIndex).TeacherDetailId;

  private static Guid GetSubjectClassId(int subjectIndex, int classIndex) => _subjects[subjectIndex].Classes.ElementAt(classIndex).ClassId;
}
