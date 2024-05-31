using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.Entities;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

class SubjectConfig(ISeedData? seedData) : IEntityTypeConfiguration<SubjectEntity>
{
  public void Configure(EntityTypeBuilder<SubjectEntity> builder)
  {
    builder.ToTable("Subject", "dbo")
      .HasKey(key => key.SubjectId);
    builder.Property(property => property.SubjectId)
      .HasDefaultValueSql("UUID()");
    builder.Property(property => property.Name)
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Description)
      .HasColumnType("longtext");
    builder.Property(property => property.Created)
      .HasDefaultValueSql("UTC_TIMESTAMP()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasMany(many => many.Classes)
      .WithOne(one => one.Subject)
      .HasForeignKey(key => key.SubjectId);
    builder.HasIndex(index => new { index.Name })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Subjects.GetAll());
  }
}
