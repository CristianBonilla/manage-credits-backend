using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class TeacherConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<TeacherEntity>
{
  public void Configure(EntityTypeBuilder<TeacherEntity> builder)
  {
    builder.ToTable("teacher")
      .HasKey(key => key.TeacherId);
    builder.Property(property => property.TeacherId)
      .HasColumnName("teacher_id")
      .HasDefaultValueSql("(UUID())");
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
    builder.Property(property => property.Profession)
      .HasColumnName("profession")
      .HasMaxLength(30)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasColumnName("created_at")
      .HasColumnType("timestamp")
      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");
    builder.Property(property => property.Version)
      .HasColumnName("version")
      .IsRowVersion();
    builder.HasMany(many => many.Details)
      .WithOne(one => one.Teacher)
      .HasForeignKey(key => key.TeacherId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasIndex(index => new { index.DocumentNumber, index.Email })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Teachers.GetAll());
  }
}

class TeacherDetailConfig(ISeedData? seedData) : IEntityTypeConfiguration<TeacherDetailEntity>
{
  public void Configure(EntityTypeBuilder<TeacherDetailEntity> builder)
  {
    builder.ToTable("teacher_detail")
      .HasKey(key => key.TeacherDetailId);
    builder.Property(property => property.TeacherDetailId)
      .HasColumnName("teacher_detail_id")
      .HasDefaultValueSql("(UUID())");
    builder.Property(property => property.TeacherId)
      .HasColumnName("teacher_id");
    builder.Property(property => property.SubjectId)
      .HasColumnName("subject_id");
    builder.Property(property => property.TotalCredits)
      .HasColumnName("total_credits")
      .HasPrecision(2, 1)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasColumnName("created_at")
      .HasColumnType("timestamp")
      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");
    builder.Property(property => property.Version)
      .HasColumnName("version")
      .IsRowVersion();
    builder.HasOne(one => one.Teacher)
      .WithMany(many => many.Details)
      .HasForeignKey(key => key.TeacherId);
    builder.HasOne(one => one.Subject)
      .WithMany()
      .HasForeignKey(key => key.SubjectId);
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.TeacherDetails.GetAll());
  }
}
