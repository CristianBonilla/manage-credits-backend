using Microsoft.EntityFrameworkCore;
using ManageCredits.Domain.Helpers;
using ManageCredits.Infrastructure.Contexts.StudentCredits;

namespace ManageCredits.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string? connectionString = configuration.GetConnectionString(ApiConfigKeys.ManageCreditsConnection) ?? throw new InvalidOperationException($"Connection string '{ApiConfigKeys.ManageCreditsConnection}' not established");
    MySqlServerVersion version = new(new Version(8, 0, 37));
    services.AddDbContextPool<StudentCreditsContext>(options => options.UseMySql(connectionString, version));
  }
}
