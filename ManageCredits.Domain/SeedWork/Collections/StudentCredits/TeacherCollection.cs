using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits;

class TeacherCollection : ISeedDataCollection<TeacherEntity, TeacherEntity>
{
  const decimal TOTAL_CREDITS = 3.0M;
  static readonly SubjectCollection _subjects = StudentCreditsCollection.Subjects;
  readonly TeacherEntity[] _teachers = new TeacherEntity[1];

  public int Length => _teachers.Length;

  public TeacherEntity this[int index] => _teachers.ElementAt(index);

  public TeacherCollection()
  {
    Init([
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
    ]);
  }

  public IEnumerable<TeacherEntity> GetAll() => [.. _teachers];

  private void Init(params TeacherEntity[] teachers)
  {
    foreach (TeacherEntity teacher in teachers)
      _teachers[^1] = teacher;
  }
}
