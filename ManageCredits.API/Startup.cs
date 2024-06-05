using Autofac;
using ManageCredits.API.Extensions;
using ManageCredits.API.Modules;
using ManageCredits.API.Options;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.API;

class Startup(IConfiguration configuration, IWebHostEnvironment env)
{
  readonly IConfiguration _configuration = configuration;
  readonly IWebHostEnvironment _env = env;

  // This method gets called by the runtime. Use this method to add services to the container
  public void ConfigureServices(IServiceCollection services) => services.InstallServicesFromAssembly(_configuration, _env);

  // Register your own things directly with Autofac here
  public static void ConfigureContainer(ContainerBuilder builder)
  {
    builder.RegisterModule<DbModule>();
    builder.RegisterModule<RepositoriesModule>();
    builder.RegisterModule<StudentCreditsModule>();
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      SwaggerOptions? swagger = _configuration.GetSection(nameof(SwaggerOptions)).Get<SwaggerOptions>();
      if (swagger is not null)
      {
        app.UseSwagger(options => options.RouteTemplate = swagger.JsonRoute);
        app.UseSwaggerUI(options => options.SwaggerEndpoint(swagger.UIEndpoint, swagger.Description));
      }
    }
    app.UseCors(ApiConfigKeys.AllowOrigins);
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });
  }
}
