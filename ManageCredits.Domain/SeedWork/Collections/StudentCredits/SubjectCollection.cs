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
      Classes = [
        new ClassEntity
        {
          ClassId = new("{b96044ee-9bb6-4733-af11-1bd8eedf8b7d}"),
          Name = "Creational Patterns",
          Description = "Learn how to provide object creation mechanisms that increase the flexibility and reuse of existing code in a way that is appropriate to the situation",
          Created = new DateTimeOffset(2024, 1, 12, 1, 0, 0, TimeSpan.Zero)
        },
        new ClassEntity
        {
          ClassId = new("{96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c}"),
          Name = "Structural Patterns",
          Description = "Learn how to facilitate efficient solutions regarding class compositions and object structures",
          Created = new DateTimeOffset(2024, 1, 13, 2, 1, 0, TimeSpan.Zero)
        },
        new ClassEntity
        {
          ClassId = new("{fe4f5476-b903-4399-b4d8-d97d9d3b1c22}"),
          Name = "Behavior Patterns",
          Description = "Learn to communicate objects, detect objects already present and manipulate them",
          Created = new DateTimeOffset(2024, 1, 14, 3, 2, 0, TimeSpan.Zero)
        }
      ],
      Created = new DateTimeOffset(2024, 1, 11, 0, 0, 0, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{8a4b2308-49d0-44db-b2d5-675742d5f2fe}"),
      Name = "S.O.L.I.D Principles",
      Description = "Learn how to apply a set of rules and best practices for software development",
      Classes = [
        new ClassEntity
        {
          ClassId = new("{85f0c48a-7b2b-456a-95fb-8c6b827a719c}"),
          Name = "Single Responsibility Principle",
          Created = new DateTimeOffset(2024, 1, 16, 1, 0, 0, TimeSpan.Zero)
        },
        new ClassEntity
        {
          ClassId = new("{4905befb-9d92-42dd-8be3-82d761339b34}"),
          Name = "Open-Closed Principle",
          Created = new DateTimeOffset(2024, 1, 17, 2, 1, 0, TimeSpan.Zero)
        },
        new ClassEntity
        {
          ClassId = new("{c5bc16d1-1046-4b44-976a-564fc5df7d65}"),
          Name = "Liskov Substitution Principle",
          Created = new DateTimeOffset(2024, 1, 18, 3, 2, 0, TimeSpan.Zero)
        },
        new ClassEntity
        {
          ClassId = new("{39537c6a-49d9-4496-a170-6e95d517ca81}"),
          Name = "Interface Segregation Principle",
          Created = new DateTimeOffset(2024, 1, 19, 4, 3, 0, TimeSpan.Zero)
        },
        new ClassEntity
        {
          ClassId = new("{a9a5f58a-2b02-4a0e-bf43-88a1080c82b4}"),
          Name = "Dependency Inversion Principle",
          Created = new DateTimeOffset(2024, 1, 20, 5, 4, 0, TimeSpan.Zero)
        }
      ],
      Created = new DateTimeOffset(2024, 1, 15, 0, 0, 0, TimeSpan.Zero)
    }
  ];

  public SubjectCollection() : base(2) { }
}
