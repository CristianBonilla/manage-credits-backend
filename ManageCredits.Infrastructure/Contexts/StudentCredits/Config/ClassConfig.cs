using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Domain.Entities;
using ManageCredits.Contracts.DTO.SeedData;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class ClassConfig(ISeedData? seedData) : IEntityTypeConfiguration<ClassEntity>
{
  public void Configure(EntityTypeBuilder<ClassEntity> builder)
  {
    builder.ToTable("class")
      .HasKey(key => key.ClassId);
    builder.Property(property => property.ClassId)
      .HasColumnName("class_id")
      .HasDefaultValueSql("(UUID())");
    builder.Property(property => property.SubjectId)
      .HasColumnName("subject_id");
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
      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");
    builder.Property(property => property.Version)
      .HasColumnName("version")
      .IsRowVersion();
    builder.HasOne(one => one.Subject)
      .WithMany(many => many.Classes)
      .HasForeignKey(key => key.SubjectId);
    builder.HasIndex(index => new { index.Name })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Classes.GetAll());
  }
}
