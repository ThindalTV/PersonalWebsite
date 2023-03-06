using Ericjohansson.Site.Client;
using Ericjohansson.Site.Client.Services;
using EricJohansson.Site.Shared.Interfaces.Blog;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IPostService, RemotePostService>();

builder.Services.AddScoped<HttpClient>(sp => new HttpClient()
{
    BaseAddress = new Uri("http://localhost:7215/api/") // Azure functions endpoint
});

await builder.Build().RunAsync();
