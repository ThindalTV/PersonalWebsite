using EricJohansson.Site.Client;
using EricJohansson.Site.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddServices(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();
