using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;
using ManageCredits.Domain.Helpers.Generators;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class StudentConfig(ISeedData? seedData) : IEntityTypeConfiguration<StudentEntity>
{
  public void Configure(EntityTypeBuilder<StudentEntity> builder)
  {
    builder.ToTable("student")
      .HasKey(key => key.StudentId);
    builder.Property(property => property.StudentId)
      .HasColumnName("student_id")
      .HasValueGenerator(typeof(NewGuidGenerator));
    builder.Property(property => property.DocumentNumber)
      .HasColumnName("document_number")
      .IsRequired();
    builder.Property(property => property.Firstname)
      .HasColumnName("firstname")
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Lastname)
      .HasColumnName("lastname")
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Email)
      .HasColumnName("email")
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasColumnName("created_at")
      .HasColumnType("timestamp")
      .HasValueGenerator(typeof(DateTimeOffsetUtcNowGenerator));
    builder.Property(property => property.Version)
      .HasColumnName("version")
      .IsRowVersion();
    builder.HasMany(many => many.Details)
      .WithOne(one => one.Student)
      .HasForeignKey(key => key.StudentId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasIndex(index => new { index.DocumentNumber, index.Email })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Students.GetAll());
  }
}

class StudentDetailConfig(ISeedData? seedData) : IEntityTypeConfiguration<StudentDetailEntity>
{
  public void Configure(EntityTypeBuilder<StudentDetailEntity> builder)
  {
    builder.ToTable("student_detail")
      .HasKey(key => key.StudentDetailId);
    builder.Property(property => property.StudentDetailId)
      .HasColumnName("student_detail_id")
      .HasValueGenerator(typeof(NewGuidGenerator));
    builder.Property(property => property.TeacherDetailId)
      .HasColumnName("teacher_detail_id");
    builder.Property(property => property.StudentId)
      .HasColumnName("student_id");
    builder.Property(property => property.ClassId)
      .HasColumnName("class_id");
    builder.Property(property => property.Status)
      .HasColumnName("status")
      .HasConversion(status => status.ToString(), status => (ClassStatus)Enum.Parse(typeof(ClassStatus), status))
      .HasMaxLength(10)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasColumnName("created_at")
      .HasColumnType("timestamp")
      .HasValueGenerator(typeof(DateTimeOffsetUtcNowGenerator));
    builder.Property(property => property.Version)
      .HasColumnName("version")
      .IsRowVersion();
    builder.HasOne(one => one.TeacherDetail)
      .WithMany()
      .HasForeignKey(key => key.TeacherDetailId);
    builder.HasOne(one => one.Student)
      .WithMany(many => many.Details)
      .HasForeignKey(key => key.StudentId);
    builder.HasOne(one => one.Class)
      .WithMany()
      .HasForeignKey(key => key.ClassId);
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.StudentDetails.GetAll());
  }
}
