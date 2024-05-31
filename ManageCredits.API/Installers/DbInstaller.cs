using ManageCredits.Domain.Helpers;
using ManageCredits.Infrastructure.Contexts.StudentCredits;
using Microsoft.EntityFrameworkCore;

namespace ManageCredits.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string? connectionString = configuration.GetConnectionString(ApiConfigKeys.ManageCreditsConnection) ?? throw new InvalidOperationException($"Connection string '{ApiConfigKeys.ManageCreditsConnection}' not established");
    services.AddDbContextPool<StudentCreditsContext>(options => options.UseMySQL(connectionString));
  }
}
