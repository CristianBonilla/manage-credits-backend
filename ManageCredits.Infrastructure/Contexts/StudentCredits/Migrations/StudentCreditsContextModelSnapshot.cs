// <auto-generated />
using System;
using ManageCredits.Infrastructure.Contexts.StudentCredits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Migrations
{
  [DbContext(typeof(StudentCreditsContext))]
  partial class StudentCreditsContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "8.0.6")
          .HasAnnotation("Relational:MaxIdentifierLength", 64);

      MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

      modelBuilder.Entity("ManageCredits.Domain.Entities.ClassEntity", b =>
          {
            b.Property<Guid>("ClassId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .HasDefaultValueSql("(UUID())");

            b.Property<DateTimeOffset>("Created")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("timestamp")
                      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

            b.Property<string>("Description")
                      .HasColumnType("longtext");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .HasColumnType("varchar(100)");

            b.Property<Guid>("SubjectId")
                      .HasColumnType("char(36)");

            b.Property<DateTime>("Version")
                      .IsConcurrencyToken()
                      .ValueGeneratedOnAddOrUpdate()
                      .HasColumnType("timestamp(6)");

            b.HasKey("ClassId");

            b.HasIndex("Name")
                      .IsUnique();

            b.HasIndex("SubjectId");

            b.ToTable("Class", (string)null);

            b.HasData(
                      new
                  {
                    ClassId = new Guid("b96044ee-9bb6-4733-af11-1bd8eedf8b7d"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 12, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Description = "Learn how to provide object creation mechanisms that increase the flexibility and reuse of existing code in a way that is appropriate to the situation",
                    Name = "Creational Patterns",
                    SubjectId = new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617")
                  },
                      new
                  {
                    ClassId = new Guid("96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 13, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Description = "Learn how to facilitate efficient solutions regarding class compositions and object structures",
                    Name = "Structural Patterns",
                    SubjectId = new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617")
                  },
                      new
                  {
                    ClassId = new Guid("fe4f5476-b903-4399-b4d8-d97d9d3b1c22"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 14, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Description = "Learn to communicate objects, detect objects already present and manipulate them",
                    Name = "Behavior Patterns",
                    SubjectId = new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617")
                  },
                      new
                  {
                    ClassId = new Guid("85f0c48a-7b2b-456a-95fb-8c6b827a719c"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Name = "Single Responsibility Principle",
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe")
                  },
                      new
                  {
                    ClassId = new Guid("4905befb-9d92-42dd-8be3-82d761339b34"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 17, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Name = "Open-Closed Principle",
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe")
                  },
                      new
                  {
                    ClassId = new Guid("c5bc16d1-1046-4b44-976a-564fc5df7d65"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 18, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Name = "Liskov Substitution Principle",
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe")
                  },
                      new
                  {
                    ClassId = new Guid("39537c6a-49d9-4496-a170-6e95d517ca81"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 19, 4, 3, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Name = "Interface Segregation Principle",
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe")
                  },
                      new
                  {
                    ClassId = new Guid("a9a5f58a-2b02-4a0e-bf43-88a1080c82b4"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 20, 5, 4, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Name = "Dependency Inversion Principle",
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe")
                  });
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.Details.StudentDetailEntity", b =>
          {
            b.Property<Guid>("StudentDetailId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .HasDefaultValueSql("(UUID())");

            b.Property<Guid>("ClassId")
                      .HasColumnType("char(36)");

            b.Property<DateTimeOffset>("Created")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("timestamp")
                      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

            b.Property<string>("Status")
                      .IsRequired()
                      .HasMaxLength(10)
                      .HasColumnType("varchar(10)");

            b.Property<Guid>("StudentId")
                      .HasColumnType("char(36)");

            b.Property<Guid>("TeacherDetailId")
                      .HasColumnType("char(36)");

            b.Property<DateTime>("Version")
                      .IsConcurrencyToken()
                      .ValueGeneratedOnAddOrUpdate()
                      .HasColumnType("timestamp(6)");

            b.HasKey("StudentDetailId");

            b.HasIndex("ClassId");

            b.HasIndex("StudentId");

            b.HasIndex("TeacherDetailId");

            b.ToTable("StudentDetail", (string)null);

            b.HasData(
                      new
                  {
                    StudentDetailId = new Guid("11ab0e13-3a0a-4fd7-9f80-3dc89b181efb"),
                    ClassId = new Guid("b96044ee-9bb6-4733-af11-1bd8eedf8b7d"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "Completed",
                    StudentId = new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"),
                    TeacherDetailId = new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2")
                  },
                      new
                  {
                    StudentDetailId = new Guid("2096ecba-29db-49d6-9646-a6c3e424953f"),
                    ClassId = new Guid("96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "Completed",
                    StudentId = new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"),
                    TeacherDetailId = new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2")
                  },
                      new
                  {
                    StudentDetailId = new Guid("eab71419-9084-4e72-9558-ce4d76f0fd30"),
                    ClassId = new Guid("fe4f5476-b903-4399-b4d8-d97d9d3b1c22"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 4, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "Completed",
                    StudentId = new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"),
                    TeacherDetailId = new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2")
                  },
                      new
                  {
                    StudentDetailId = new Guid("90812e38-67ad-4207-8017-e2b09231231e"),
                    ClassId = new Guid("85f0c48a-7b2b-456a-95fb-8c6b827a719c"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "InProgress",
                    StudentId = new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"),
                    TeacherDetailId = new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046")
                  },
                      new
                  {
                    StudentDetailId = new Guid("6647c961-57b7-4e04-ad8f-3213a6b85f89"),
                    ClassId = new Guid("4905befb-9d92-42dd-8be3-82d761339b34"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "Completed",
                    StudentId = new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"),
                    TeacherDetailId = new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046")
                  },
                      new
                  {
                    StudentDetailId = new Guid("7f8a160f-b415-486d-bce2-af44c58af36c"),
                    ClassId = new Guid("c5bc16d1-1046-4b44-976a-564fc5df7d65"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 4, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "InProgress",
                    StudentId = new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"),
                    TeacherDetailId = new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046")
                  },
                      new
                  {
                    StudentDetailId = new Guid("fa2a8cc5-c7ae-4577-a981-3d4ab4a2ef1b"),
                    ClassId = new Guid("39537c6a-49d9-4496-a170-6e95d517ca81"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 5, 4, 3, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "InProgress",
                    StudentId = new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"),
                    TeacherDetailId = new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046")
                  },
                      new
                  {
                    StudentDetailId = new Guid("58696965-ccef-46b8-b791-74c4f8c28f25"),
                    ClassId = new Guid("a9a5f58a-2b02-4a0e-bf43-88a1080c82b4"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 6, 5, 4, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Status = "Pending",
                    StudentId = new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"),
                    TeacherDetailId = new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046")
                  });
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.Details.TeacherDetailEntity", b =>
          {
            b.Property<Guid>("TeacherDetailId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .HasDefaultValueSql("(UUID())");

            b.Property<DateTimeOffset>("Created")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("timestamp")
                      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

            b.Property<Guid>("SubjectId")
                      .HasColumnType("char(36)");

            b.Property<Guid>("TeacherId")
                      .HasColumnType("char(36)");

            b.Property<decimal>("TotalCredits")
                      .HasPrecision(2, 1)
                      .HasColumnType("decimal(2,1)");

            b.Property<DateTime>("Version")
                      .IsConcurrencyToken()
                      .ValueGeneratedOnAddOrUpdate()
                      .HasColumnType("timestamp(6)");

            b.HasKey("TeacherDetailId");

            b.HasIndex("SubjectId");

            b.HasIndex("TeacherId");

            b.ToTable("TeacherDetail", (string)null);

            b.HasData(
                      new
                  {
                    TeacherDetailId = new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2"),
                    Created = new DateTimeOffset(new DateTime(2024, 2, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    SubjectId = new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"),
                    TeacherId = new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"),
                    TotalCredits = 3.0m
                  },
                      new
                  {
                    TeacherDetailId = new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046"),
                    Created = new DateTimeOffset(new DateTime(2024, 2, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"),
                    TeacherId = new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"),
                    TotalCredits = 3.0m
                  });
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.StudentEntity", b =>
          {
            b.Property<Guid>("StudentId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .HasDefaultValueSql("(UUID())");

            b.Property<DateTimeOffset>("Created")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("timestamp")
                      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

            b.Property<string>("DocumentNumber")
                      .IsRequired()
                      .HasColumnType("varchar(255)");

            b.Property<string>("Email")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .HasColumnType("varchar(100)");

            b.Property<string>("Firstname")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .HasColumnType("varchar(50)");

            b.Property<string>("Lastname")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .HasColumnType("varchar(50)");

            b.Property<DateTime>("Version")
                      .IsConcurrencyToken()
                      .ValueGeneratedOnAddOrUpdate()
                      .HasColumnType("timestamp(6)");

            b.HasKey("StudentId");

            b.HasIndex("DocumentNumber", "Email")
                      .IsUnique();

            b.ToTable("Student", (string)null);

            b.HasData(
                      new
                  {
                    StudentId = new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    DocumentNumber = "1033671288",
                    Email = "angela.suarez@outlook.com",
                    Firstname = "Angela Natalia",
                    Lastname = "Suarez"
                  },
                      new
                  {
                    StudentId = new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"),
                    Created = new DateTimeOffset(new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    DocumentNumber = "1109432112",
                    Email = "jeison.bonilla@gmail.com",
                    Firstname = "Jeison Andrés",
                    Lastname = "Bonilla"
                  });
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.SubjectEntity", b =>
          {
            b.Property<Guid>("SubjectId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .HasDefaultValueSql("(UUID())");

            b.Property<DateTimeOffset>("Created")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("timestamp")
                      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

            b.Property<string>("Description")
                      .HasColumnType("longtext");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .HasColumnType("varchar(100)");

            b.Property<DateTime>("Version")
                      .IsConcurrencyToken()
                      .ValueGeneratedOnAddOrUpdate()
                      .HasColumnType("timestamp(6)");

            b.HasKey("SubjectId");

            b.HasIndex("Name")
                      .IsUnique();

            b.ToTable("Subject", (string)null);

            b.HasData(
                      new
                  {
                    SubjectId = new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Description = "Learn to identify system problems with a general, reusable, scalable and applicable solution",
                    Name = "Design Patterns"
                  },
                      new
                  {
                    SubjectId = new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"),
                    Created = new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    Description = "Learn how to apply a set of rules and best practices for software development",
                    Name = "S.O.L.I.D Principles"
                  });
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.TeacherEntity", b =>
          {
            b.Property<Guid>("TeacherId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)")
                      .HasDefaultValueSql("(UUID())");

            b.Property<DateTimeOffset>("Created")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("timestamp")
                      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

            b.Property<string>("DocumentNumber")
                      .IsRequired()
                      .HasColumnType("varchar(255)");

            b.Property<string>("Email")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .HasColumnType("varchar(100)");

            b.Property<string>("Firstname")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .HasColumnType("varchar(50)");

            b.Property<string>("Lastname")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .HasColumnType("varchar(50)");

            b.Property<string>("Profession")
                      .IsRequired()
                      .HasMaxLength(30)
                      .IsUnicode(false)
                      .HasColumnType("varchar(30)");

            b.Property<DateTime>("Version")
                      .IsConcurrencyToken()
                      .ValueGeneratedOnAddOrUpdate()
                      .HasColumnType("timestamp(6)");

            b.HasKey("TeacherId");

            b.HasIndex("DocumentNumber", "Email")
                      .IsUnique();

            b.ToTable("Teacher", (string)null);

            b.HasData(
                      new
                  {
                    TeacherId = new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"),
                    Created = new DateTimeOffset(new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                    DocumentNumber = "1023944678",
                    Email = "cristian10camilo95@gmail.com",
                    Firstname = "Cristian Camilo",
                    Lastname = "Bonilla",
                    Profession = "Senior Software Developer"
                  });
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.ClassEntity", b =>
          {
            b.HasOne("ManageCredits.Domain.Entities.SubjectEntity", "Subject")
                      .WithMany("Classes")
                      .HasForeignKey("SubjectId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Subject");
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.Details.StudentDetailEntity", b =>
          {
            b.HasOne("ManageCredits.Domain.Entities.ClassEntity", "Class")
                      .WithMany()
                      .HasForeignKey("ClassId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("ManageCredits.Domain.Entities.StudentEntity", "Student")
                      .WithMany("Details")
                      .HasForeignKey("StudentId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("ManageCredits.Domain.Entities.Details.TeacherDetailEntity", "TeacherDetail")
                      .WithMany()
                      .HasForeignKey("TeacherDetailId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Class");

            b.Navigation("Student");

            b.Navigation("TeacherDetail");
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.Details.TeacherDetailEntity", b =>
          {
            b.HasOne("ManageCredits.Domain.Entities.SubjectEntity", "Subject")
                      .WithMany()
                      .HasForeignKey("SubjectId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("ManageCredits.Domain.Entities.TeacherEntity", "Teacher")
                      .WithMany("Details")
                      .HasForeignKey("TeacherId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Subject");

            b.Navigation("Teacher");
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.StudentEntity", b =>
          {
            b.Navigation("Details");
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.SubjectEntity", b =>
          {
            b.Navigation("Classes");
          });

      modelBuilder.Entity("ManageCredits.Domain.Entities.TeacherEntity", b =>
          {
            b.Navigation("Details");
          });
#pragma warning restore 612, 618
    }
  }
}
