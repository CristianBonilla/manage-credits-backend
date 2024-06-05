using Autofac;
using ManageCredits.Contracts.Services;
using ManageCredits.Domain.Services;

namespace ManageCredits.API.Modules;

class StudentCreditsModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<TeacherService>()
      .As<ITeacherService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentService>()
      .As<IStudentService>()
      .InstancePerLifetimeScope();
  }
}
