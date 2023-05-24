using Ericjohansson.Site.Client;
using EricJohansson.Site.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddServices("http://localhost:7215/api/");

// Register the Telerik services.
builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();
