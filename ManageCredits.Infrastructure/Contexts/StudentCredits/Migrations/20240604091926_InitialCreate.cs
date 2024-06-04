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
          name: "student",
          columns: table => new
          {
            student_id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            document_number = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_student", x => x.student_id);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "subject",
          columns: table => new
          {
            subject_id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            description = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_subject", x => x.subject_id);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "teacher",
          columns: table => new
          {
            teacher_id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            document_number = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            profession = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_teacher", x => x.teacher_id);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "class",
          columns: table => new
          {
            class_id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            subject_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            description = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_class", x => x.class_id);
            table.ForeignKey(
                      name: "FK_class_subject_subject_id",
                      column: x => x.subject_id,
                      principalTable: "subject",
                      principalColumn: "subject_id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "teacher_detail",
          columns: table => new
          {
            teacher_detail_id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            teacher_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            subject_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            total_credits = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
            created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_teacher_detail", x => x.teacher_detail_id);
            table.ForeignKey(
                      name: "FK_teacher_detail_subject_subject_id",
                      column: x => x.subject_id,
                      principalTable: "subject",
                      principalColumn: "subject_id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_teacher_detail_teacher_teacher_id",
                      column: x => x.teacher_id,
                      principalTable: "teacher",
                      principalColumn: "teacher_id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "student_detail",
          columns: table => new
          {
            student_detail_id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(UUID())", collation: "ascii_general_ci"),
            teacher_detail_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            student_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            class_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
            status = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
            version = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_student_detail", x => x.student_detail_id);
            table.ForeignKey(
                      name: "FK_student_detail_class_class_id",
                      column: x => x.class_id,
                      principalTable: "class",
                      principalColumn: "class_id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_student_detail_student_student_id",
                      column: x => x.student_id,
                      principalTable: "student",
                      principalColumn: "student_id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_student_detail_teacher_detail_teacher_detail_id",
                      column: x => x.teacher_detail_id,
                      principalTable: "teacher_detail",
                      principalColumn: "teacher_detail_id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.InsertData(
          table: "student",
          columns: new[] { "student_id", "created_at", "document_number", "email", "firstname", "lastname" },
          values: new object[,]
          {
                    { new Guid("107e7e52-74fc-4589-b7d9-5f1ffc434637"), new DateTimeOffset(new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1109432112", "jeison.bonilla@gmail.com", "Jeison Andrés", "Bonilla" },
                    { new Guid("ee466b07-1d3e-4356-8d03-0067d5ba30e5"), new DateTimeOffset(new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1033671288", "angela.suarez@outlook.com", "Angela Natalia", "Suarez" }
          });

      migrationBuilder.InsertData(
          table: "subject",
          columns: new[] { "subject_id", "created_at", "description", "name" },
          values: new object[,]
          {
                    { new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"), new DateTimeOffset(new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn to identify system problems with a general, reusable, scalable and applicable solution", "Design Patterns" },
                    { new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"), new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learn how to apply a set of rules and best practices for software development", "S.O.L.I.D Principles" }
          });

      migrationBuilder.InsertData(
          table: "teacher",
          columns: new[] { "teacher_id", "created_at", "document_number", "email", "firstname", "lastname", "profession" },
          values: new object[] { new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), new DateTimeOffset(new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1023944678", "cristian10camilo95@gmail.com", "Cristian Camilo", "Bonilla", "Senior Software Developer" });

      migrationBuilder.InsertData(
          table: "class",
          columns: new[] { "class_id", "created_at", "description", "name", "subject_id" },
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
          table: "teacher_detail",
          columns: new[] { "teacher_detail_id", "created_at", "subject_id", "teacher_id", "total_credits" },
          values: new object[,]
          {
                    { new Guid("f79f1e3c-8974-4b38-8f9d-72e738efb046"), new DateTimeOffset(new DateTime(2024, 2, 3, 2, 1, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8a4b2308-49d0-44db-b2d5-675742d5f2fe"), new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), 3.0m },
                    { new Guid("f87b9e01-7066-4a18-bbe5-560a9c6ddec2"), new DateTimeOffset(new DateTime(2024, 2, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("2ee9ebee-460c-4389-a50b-f0b602a2f617"), new Guid("d3e5862d-3c30-4b35-8a0d-4632572aae47"), 3.0m }
          });

      migrationBuilder.InsertData(
          table: "student_detail",
          columns: new[] { "student_detail_id", "class_id", "created_at", "status", "student_id", "teacher_detail_id" },
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
          name: "IX_class_name",
          table: "class",
          column: "name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_class_subject_id",
          table: "class",
          column: "subject_id");

      migrationBuilder.CreateIndex(
          name: "IX_student_document_number_email",
          table: "student",
          columns: new[] { "document_number", "email" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_student_detail_class_id",
          table: "student_detail",
          column: "class_id");

      migrationBuilder.CreateIndex(
          name: "IX_student_detail_student_id",
          table: "student_detail",
          column: "student_id");

      migrationBuilder.CreateIndex(
          name: "IX_student_detail_teacher_detail_id",
          table: "student_detail",
          column: "teacher_detail_id");

      migrationBuilder.CreateIndex(
          name: "IX_subject_name",
          table: "subject",
          column: "name",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_teacher_document_number_email",
          table: "teacher",
          columns: new[] { "document_number", "email" },
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_teacher_detail_subject_id",
          table: "teacher_detail",
          column: "subject_id");

      migrationBuilder.CreateIndex(
          name: "IX_teacher_detail_teacher_id",
          table: "teacher_detail",
          column: "teacher_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "student_detail");

      migrationBuilder.DropTable(
          name: "class");

      migrationBuilder.DropTable(
          name: "student");

      migrationBuilder.DropTable(
          name: "teacher_detail");

      migrationBuilder.DropTable(
          name: "subject");

      migrationBuilder.DropTable(
          name: "teacher");
    }
  }
}
