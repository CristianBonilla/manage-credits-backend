using Autofac;
using ManageCredits.Contracts.DTO.SeedData;
using ManageCredits.Domain.SeedWork;

namespace ManageCredits.API.Modules;

class DbModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<SeedData>()
      .As<ISeedData>()
      .InstancePerLifetimeScope();
  }
}
