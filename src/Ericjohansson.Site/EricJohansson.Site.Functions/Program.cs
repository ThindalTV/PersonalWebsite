using EricJohansson.Site.Shared.Interfaces.Blog;
using EricJohansson.Site.Shared.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults();
    
builder.ConfigureServices(services =>
{
    services.AddScoped<IThoughtsService, StaticThoughtsService>();
});

var host = builder.Build();

await host.RunAsync();
