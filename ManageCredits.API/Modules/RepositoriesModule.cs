using Autofac;
using ManageCredits.Contracts.Repositories;
using ManageCredits.Infrastructure.Repositories;
using ManageCredits.Infrastructure.Repositories.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Details;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces.Details;

namespace ManageCredits.API.Modules;

class RepositoriesModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(RepositoryContext<>))
      .As(typeof(IRepositoryContext<>))
      .InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(Repository<,>))
      .As(typeof(IRepository<,>))
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentCreditsRepositoryContext>()
      .As<IStudentCreditsRepositoryContext>()
      .InstancePerLifetimeScope();

    builder.RegisterType<SubjectRepository>()
      .As<ISubjectRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<ClassRepository>()
      .As<IClassRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<TeacherRepository>()
      .As<ITeacherRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentRepository>()
      .As<IStudentRepository>()
      .InstancePerLifetimeScope();

    builder.RegisterType<TeacherDetailRepository>()
      .As<ITeacherDetailRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentDetailRepository>()
      .As<IStudentDetailRepository>()
      .InstancePerLifetimeScope();
  }
}
