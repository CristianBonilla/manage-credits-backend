using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Migrations
{
  /// <inheritdoc />
  public partial class InitialCreate : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "Student",
          columns: table => new
          {
            StudentId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            DocumentNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Created = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Student", x => x.StudentId);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "Subject",
          columns: table => new
          {
            SubjectId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Description = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Created = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Subject", x => x.SubjectId);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "Teacher",
          columns: table => new
          {
            TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            DocumentNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Profession = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Created = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Teacher", x => x.TeacherId);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "Class",
          columns: table => new
          {
            ClassId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            SubjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Description = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Created = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Class", x => x.ClassId);
            table.ForeignKey(
                      name: "FK_Class_Subject_SubjectId",
                      column: x => x.SubjectId,
                      principalTable: "Subject",
                      principalColumn: "SubjectId",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "TeacherDetail",
          columns: table => new
          {
            TeacherDetailId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            SubjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            TotalCredits = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
            Created = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_TeacherDetail", x => x.TeacherDetailId);
            table.ForeignKey(
                      name: "FK_TeacherDetail_Subject_SubjectId",
                      column: x => x.SubjectId,
                      principalTable: "Subject",
                      principalColumn: "SubjectId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_TeacherDetail_Teacher_TeacherId",
                      column: x => x.TeacherId,
                      principalTable: "Teacher",
                      principalColumn: "TeacherId",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "StudentDetail",
          columns: table => new
          {
            StudentDetailId = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            TeacherDetailId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            ClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            Status = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Created = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            Version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_StudentDetail", x => x.StudentDetailId);
            table.ForeignKey(
                      name: "FK_StudentDetail_Class_ClassId",
                      column: x => x.ClassId,
                      principalTable: "Class",
                      principalColumn: "ClassId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_StudentDetail_Student_StudentId",
                      column: x => x.StudentId,
                      principalTable: "Student",
                      principalColumn: "StudentId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_StudentDetail_TeacherDetail_TeacherDetailId",
                      column: x => x.TeacherDetailId,
                      principalTable: "TeacherDetail",
                      principalColumn: "TeacherDetailId",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.InsertData(
          table: "Student",
          columns: new[] { "StudentId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname" },
          values: new object[,]
          {
                    { new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new DateTimeOffset(new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1109432112", "jeison.bonilla@gmail.com", "Jeison Andrés", "Bonilla" },
                    { new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new DateTimeOffset(new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1033671288", "angela.suarez@outlook.com", "Angela Natalia", "Suarez" }
          });

      migrationBuilder.InsertData(
          table: "Subject",
          columns: new[] { "SubjectId", "Created", "Description", "Name" },
          values: new object[,]
          {
                    { new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"), new DateTimeOffset(new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn to identify system problems with a general, reusable, scalable and applicable solution", "Design Patterns" },
                    { new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"), new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to apply a set of rules and best practices for software development", "S.O.L.I.D Principles" }
          });

      migrationBuilder.InsertData(
          table: "Teacher",
          columns: new[] { "TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession" },
          values: new object[] { new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), new DateTimeOffset(new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1023944678", "cristian10camilo95@gmail.com", "Cristian Camilo", "Bonilla", "Senior Software Developer" });

      migrationBuilder.InsertData(
          table: "Class",
          columns: new[] { "ClassId", "Created", "Description", "Name", "SubjectId" },
          values: new object[,]
          {
                    { new Guid("39537c6a-49d9-4496-a170-6e95d517ca81"), new DateTimeOffset(new DateTime(2024, 1, 19, 4, 3, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Interface Segregation Principle", new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe") },
                    { new Guid("4905befb-9d92-42dd-8be3-82d761339b34"), new DateTimeOffset(new DateTime(2024, 1, 17, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Open-Closed Principle", new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe") },
                    { new Guid("85f0c48a-7b2b-456a-95fb-8c6b827a719c"), new DateTimeOffset(new DateTime(2024, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Single Responsibility Principle", new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe") },
                    { new Guid("96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c"), new DateTimeOffset(new DateTime(2024, 1, 13, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to facilitate efficient solutions regarding class compositions and object structures", "Structural Patterns", new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617") },
                    { new Guid("a9a5f58a-2b02-4a0e-bf43-88a1080c82b4"), new DateTimeOffset(new DateTime(2024, 1, 20, 5, 4, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dependency Inversion Principle", new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe") },
                    { new Guid("b96044ee-9bb6-4733-af11-1bd8eedf8b7d"), new DateTimeOffset(new DateTime(2024, 1, 12, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to provide object creation mechanisms that increase the flexibility and reuse of existing code in a way that is appropriate to the situation", "Creational Patterns", new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617") },
                    { new Guid("c5bc16d1-1046-4b44-976a-564fc5df7d65"), new DateTimeOffset(new DateTime(2024, 1, 18, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Liskov Substitution Principle", new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe") },
                    { new Guid("fe4f5476-b903-4399-b4d8-d97d9d3b1c22"), new DateTimeOffset(new DateTime(2024, 1, 14, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn to communicate objects, detect objects already present and manipulate them", "Behavior Patterns", new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617") }
          });

      migrationBuilder.InsertData(
          table: "TeacherDetail",
          columns: new[] { "TeacherDetailId", "Created", "SubjectId", "TeacherId", "TotalCredits" },
          values: new object[,]
          {
                    { new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046"), new DateTimeOffset(new DateTime(2024, 2, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"), new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), 3.0m },
                    { new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2"), new DateTimeOffset(new DateTime(2024, 2, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"), new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), 3.0m }
          });

      migrationBuilder.InsertData(
          table: "StudentDetail",
          columns: new[] { "StudentDetailId", "ClassId", "Created", "Status", "StudentId", "TeacherDetailId" },
          values: new object[,]
          {
                    { new Guid("11ab0e13-3a0a-4fd7-9f80-3dc89b181efb"), new Guid("b96044ee-9bb6-4733-af11-1bd8eedf8b7d"), new DateTimeOffset(new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Completed", new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2") },
                    { new Guid("2096ecba-29db-49d6-9646-a6c3e424953f"), new Guid("96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c"), new DateTimeOffset(new DateTime(2024, 3, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Completed", new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2") },
                    { new Guid("58696965-ccef-46b8-b791-74c4f8c28f25"), new Guid("a9a5f58a-2b02-4a0e-bf43-88a1080c82b4"), new DateTimeOffset(new DateTime(2024, 3, 6, 5, 4, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pending", new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") },
                    { new Guid("6647c961-57b7-4e04-ad8f-3213a6b85f89"), new Guid("4905befb-9d92-42dd-8be3-82d761339b34"), new DateTimeOffset(new DateTime(2024, 3, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Completed", new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") },
                    { new Guid("7f8a160f-b415-486d-bce2-af44c58af36c"), new Guid("c5bc16d1-1046-4b44-976a-564fc5df7d65"), new DateTimeOffset(new DateTime(2024, 3, 4, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "InProgress", new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") },
                    { new Guid("90812e38-67ad-4207-8017-e2b09231231e"), new Guid("85f0c48a-7b2b-456a-95fb-8c6b827a719c"), new DateTimeOffset(new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "InProgress", new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") },
                    { new Guid("eab71419-9084-4e72-9558-ce4d76f0fd30"), new Guid("fe4f5476-b903-4399-b4d8-d97d9d3b1c22"), new DateTimeOffset(new DateTime(2024, 3, 4, 3, 2, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Completed", new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2") },
                    { new Guid("fa2a8cc5-c7ae-4577-a981-3d4ab4a2ef1b"), new Guid("39537c6a-49d9-4496-a170-6e95d517ca81"), new DateTimeOffset(new DateTime(2024, 3, 5, 4, 3, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "InProgress", new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046") }
          });

      migrationBuilder.CreateIndex(
          name: "IX_Class_Name",
          table: "Class",
          column: "Name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Class_SubjectId",
          table: "Class",
          column: "SubjectId");

      migrationBuilder.CreateIndex(
          name: "IX_Student_DocumentNumber_Email",
          table: "Student",
          columns: new[] { "DocumentNumber", "Email" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_StudentDetail_ClassId",
          table: "StudentDetail",
          column: "ClassId");

      migrationBuilder.CreateIndex(
          name: "IX_StudentDetail_StudentId",
          table: "StudentDetail",
          column: "StudentId");

      migrationBuilder.CreateIndex(
          name: "IX_StudentDetail_TeacherDetailId",
          table: "StudentDetail",
          column: "TeacherDetailId");

      migrationBuilder.CreateIndex(
          name: "IX_Subject_Name",
          table: "Subject",
          column: "Name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Teacher_DocumentNumber_Email",
          table: "Teacher",
          columns: new[] { "DocumentNumber", "Email" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_TeacherDetail_SubjectId",
          table: "TeacherDetail",
          column: "SubjectId");

      migrationBuilder.CreateIndex(
          name: "IX_TeacherDetail_TeacherId",
          table: "TeacherDetail",
          column: "TeacherId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "StudentDetail");

      migrationBuilder.DropTable(
          name: "Class");

      migrationBuilder.DropTable(
          name: "Student");

      migrationBuilder.DropTable(
          name: "TeacherDetail");

      migrationBuilder.DropTable(
          name: "Subject");

      migrationBuilder.DropTable(
          name: "Teacher");
    }
  }
}
