using Microsoft.EntityFrameworkCore;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Infrastructure.Extensions;
using ManageCredits.Infrastructure.Contexts.StudentCredits.Config;

namespace ManageCredits.Infrastructure.Contexts.StudentCredits;

public class StudentCreditsContext(DbContextOptions<StudentCreditsContext> options, ISeedData? seedData) : DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyEntityTypeConfig(seedData,
      typeof(SubjectConfig),
      typeof(ClassConfig),
      typeof(TeacherConfig),
      typeof(TeacherDetailConfig),
      typeof(StudentConfig),
      typeof(StudentDetailConfig));
  }
}
