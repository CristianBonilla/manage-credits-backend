using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class StudentConfig(ISeedData? seedData) : IEntityTypeConfiguration<StudentEntity>
{
  public void Configure(EntityTypeBuilder<StudentEntity> builder)
  {
    builder.ToTable("Student", "dbo")
      .HasKey(key => key.StudentId);
    builder.Property(property => property.StudentId)
      .HasDefaultValueSql("UUID()");
    builder.Property(property => property.DocumentNumber)
      .IsRequired();
    builder.Property(property => property.Firstname)
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Lastname)
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Email)
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasDefaultValueSql("UTC_TIMESTAMP()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasMany(many => many.Details)
      .WithOne(one => one.Student)
      .HasForeignKey(key => key.StudentId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasIndex(index => new { index.DocumentNumber, index.Email })
      .IsUnique();
    //if (seedData is not null)
    //  builder.HasData(seedData.StudentCredits.Students.GetAll());
  }
}

class StudentDetailConfig : IEntityTypeConfiguration<StudentDetailEntity>
{
  public void Configure(EntityTypeBuilder<StudentDetailEntity> builder)
  {
    builder.ToTable("StudentDetail", "dbo")
      .HasKey(key => key.StudentDetailId);
    builder.Property(property => property.StudentDetailId)
      .HasDefaultValueSql("UUID()");
    builder.Property(property => property.Status)
      .HasConversion(status => status.ToString(), status => (ClassStatus)Enum.Parse(typeof(ClassStatus), status))
      .HasMaxLength(10)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasDefaultValueSql("UTC_TIMESTAMP()");
    builder.Property(property => property.Version)
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
  }
}
