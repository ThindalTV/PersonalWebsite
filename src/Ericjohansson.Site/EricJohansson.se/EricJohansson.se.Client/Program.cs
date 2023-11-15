using EricJohansson.Site.Shared.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddServices("https://localhost:5001");

await builder.Build().RunAsync();
