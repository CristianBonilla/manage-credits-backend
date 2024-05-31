using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits;

class TeacherCollection : SeedDataCollection<TeacherEntity>
{
  protected override TeacherEntity[] Collection => [
    new TeacherEntity
    {
      TeacherId = new("{d3e5862d-3c30-4b35-8a0d-4632572aae47}"),
      DocumentNumber = "1023944678",
      Firstname = "Cristian Camilo",
      Lastname = "Bonilla",
      Email = "cristian10camilo95@gmail.com",
      Profession = "Senior Software Developer",
      Created = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero)
    }
  ];

  public TeacherCollection() : base(1) { }
}
