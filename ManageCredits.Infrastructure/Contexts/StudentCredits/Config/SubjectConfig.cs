using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers.Generators;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class SubjectConfig(ISeedData? seedData) : IEntityTypeConfiguration<SubjectEntity>
{
  public void Configure(EntityTypeBuilder<SubjectEntity> builder)
  {
    builder.ToTable("subject")
      .HasKey(key => key.SubjectId);
    builder.Property(property => property.SubjectId)
      .HasColumnName("subject_id")
      .HasValueGenerator(typeof(NewGuidGenerator));
    builder.Property(property => property.Name)
      .HasColumnName("name")
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Description)
      .HasColumnName("description")
      .HasColumnType("longtext");
    builder.Property(property => property.Created)
      .HasColumnName("created_at")
      .HasColumnType("timestamp")
      .HasValueGenerator(typeof(DateTimeOffsetUtcNowGenerator));
    builder.Property(property => property.Version)
      .HasColumnName("version")
      .IsRowVersion();
    builder.HasMany(many => many.Classes)
      .WithOne(one => one.Subject)
      .HasForeignKey(key => key.ClassId);
    builder.HasIndex(index => new { index.Name })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Subjects.GetAll());
  }
}
