using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Domain.Entities;
using ManageCredits.Contracts.DTO.SeedData;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class ClassConfig(ISeedData? seedData) : IEntityTypeConfiguration<ClassEntity>
{
  public void Configure(EntityTypeBuilder<ClassEntity> builder)
  {
    builder.ToTable("Class")
      .HasKey(key => key.ClassId);
    builder.Property(property => property.ClassId)
      .HasDefaultValueSql("(UUID())");
    builder.Property(property => property.Name)
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Description)
      .HasColumnType("longtext");
    builder.Property(property => property.Created)
      .HasColumnType("timestamp")
      .HasDefaultValueSql("(CURRENT_TIMESTAMP)");
    builder.Property(property => property.Version)
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
