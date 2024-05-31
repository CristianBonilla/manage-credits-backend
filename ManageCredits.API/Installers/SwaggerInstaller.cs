using ManageCredits.API.Filters;
using ManageCredits.API.Options;

namespace ManageCredits.API.Installers;

class SwaggerInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
    services.Configure<SwaggerOptions>(swaggerSection);
    SwaggerOptions? swagger = swaggerSection.Get<SwaggerOptions>();
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc("v1", new()
      {
        Title = "Manage Credits API",
        Version = "v1",
        Description = "Manage credits for students who complete the subjects",
        Contact = swagger is null ? default : swagger.Contact
      });
      options.SchemaFilter<EnumSchemaFilter>();
    });
  }
}
