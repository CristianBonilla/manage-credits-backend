using Autofac.Extensions.DependencyInjection;
using ManageCredits.API.Extensions;
using ManageCredits.Infrastructure.Contexts.StudentCredits;

namespace ManageCredits.API;

class Program
{
  public static async Task Main(string[] args)
  {
    IHost host = CreateHostBuilder(args).Build();
    await host.DbStart<StudentCreditsContext>().Migrate();
    await host.RunAsync();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .UseServiceProviderFactory(new AutofacServiceProviderFactory())
      .ConfigureWebHostDefaults(builder =>
      {
        builder.UseStartup<Startup>();
      });
}
