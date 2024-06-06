using AutoMapper;
using ManageCredits.API.Mappers;

namespace ManageCredits.API.Installers;

class MapperInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    MapperConfiguration mapperConfiguration = MapperStart.Build();
    IMapper mapper = mapperConfiguration.CreateMapper();
    services.AddSingleton(mapper);
  }
}
