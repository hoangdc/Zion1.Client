using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zion1.Common.Helper.Api;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Services.AddApiSettings();

await builder.Build().RunAsync();
