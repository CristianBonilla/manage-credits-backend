using AutoMapper;
using ManageCredits.API.Mappers.Profiles;

namespace ManageCredits.API.Mappers;

class MapperStart
{
  public static MapperConfiguration Build()
  {
    MapperConfiguration configuration = new(configuration => configuration.AddProfile<StudentCreditsProfile>());
    configuration.AssertConfigurationIsValid();

    return configuration;
  }
}
