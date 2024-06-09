using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Domain.SeedWork.Collections.StudentCredits;

class ClassCollection : SeedDataCollection<ClassEntity>
{
  static readonly SubjectCollection _subjects = StudentCreditsCollection.Subjects;

  protected override ClassEntity[] Collection => [
    new ClassEntity
    {
      SubjectId = _subjects[0].SubjectId,
      ClassId = new("{b96044ee-9bb6-4733-af11-1bd8eedf8b7d}"),
      Name = "Why design patterns?",
      Description = "Learn how design patterns have become an object of some controversy in the programming world of late, largely due to their perceived \"overuse\", leading to code that can be more difficult to understand and manage",
      Created = new DateTimeOffset(2024, 1, 12, 1, 0, 1, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[1].SubjectId,
      ClassId = new("{96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c}"),
      Name = "Why S.O.L.I.D Principles?",
      Description = "Conozca los principios Single Reponsability Principle (SRP), Open/Closed Principle (OCP), Liskov Substitution Principle (LSP), Interface Segregation Principle (ISP) y Dependency Inversion Principle (DIP)",
      Created = new DateTimeOffset(2024, 1, 13, 2, 1, 2, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[2].SubjectId,
      ClassId = new("{fe4f5476-b903-4399-b4d8-d97d9d3b1c22}"),
      Name = "DDD Architecture",
      Description = "Learn how this domain-oriented architecture helps us solve the central problem of the domain in an effective way",
      Created = new DateTimeOffset(2024, 1, 14, 3, 2, 3, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[3].SubjectId,
      ClassId = new("{85f0c48a-7b2b-456a-95fb-8c6b827a719c}"),
      Name = "Implement microservices architecture",
      Created = new DateTimeOffset(2024, 1, 16, 1, 0, 4, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[4].SubjectId,
      ClassId = new("{4905befb-9d92-42dd-8be3-82d761339b34}"),
      Name = "Learn about QA Automation",
      Created = new DateTimeOffset(2024, 1, 17, 2, 1, 5, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[5].SubjectId,
      ClassId = new("{c5bc16d1-1046-4b44-976a-564fc5df7d65}"),
      Name = "Learn QA Automation Tools",
      Created = new DateTimeOffset(2024, 1, 18, 3, 2, 6, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[6].SubjectId,
      ClassId = new("{39537c6a-49d9-4496-a170-6e95d517ca81}"),
      Name = "Learn about Scrum Master",
      Created = new DateTimeOffset(2024, 1, 19, 4, 3, 7, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[7].SubjectId,
      ClassId = new("{a9a5f58a-2b02-4a0e-bf43-88a1080c82b4}"),
      Name = "Become a Scrum Master expert",
      Created = new DateTimeOffset(2024, 1, 20, 5, 4, 8, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[8].SubjectId,
      ClassId = new("{27344f1d-c2d4-46eb-8a70-39943856ccf7}"),
      Name = "Master the TypeScript superset",
      Created = new DateTimeOffset(2024, 1, 21, 6, 5, 9, TimeSpan.Zero)
    },
    new ClassEntity
    {
      SubjectId = _subjects[9].SubjectId,
      ClassId = new("{1a3112f6-c99a-42e7-a25e-e912bc367954}"),
      Name = "Inventory application with Angular",
      Created = new DateTimeOffset(2024, 1, 22, 7, 6, 10, TimeSpan.Zero)
    }
  ];

  public ClassCollection() : base(10) { }
}
