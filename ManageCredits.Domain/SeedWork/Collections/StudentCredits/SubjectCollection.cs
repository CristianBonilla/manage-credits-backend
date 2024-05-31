using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits;

class SubjectCollection : SeedDataCollection<SubjectEntity>
{
  protected override SubjectEntity[] Collection => [
    new SubjectEntity
    {
      SubjectId = new("{2ee9ebee-460c-4389-a50b-f0b602a2f617}"),
      Name = "Design Patterns",
      Description = "Learn to identify system problems with a general, reusable, scalable and applicable solution",
      Created = new DateTimeOffset(2024, 1, 11, 0, 0, 0, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{8a4b2308-49d0-44db-b2d5-675742d5f2fe}"),
      Name = "S.O.L.I.D Principles",
      Description = "Learn how to apply a set of rules and best practices for software development",
      Created = new DateTimeOffset(2024, 1, 15, 0, 0, 0, TimeSpan.Zero)
    }
  ];

  public SubjectCollection() : base(2) { }
}
