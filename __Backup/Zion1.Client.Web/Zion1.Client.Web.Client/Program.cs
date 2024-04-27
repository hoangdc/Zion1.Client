using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zion1.Common.Helper.Api;
using Zion1.Common.Helper.Cache;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Add Cache Service
builder.Services.AddCacheService();

// Add Api Settings for ApiConsumer
await builder.Services.AddApiSettings();


await builder.Build().RunAsync();
