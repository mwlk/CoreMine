using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CoreMine.Client;
using CoreMine.Client.Extensions;
using CoreMine.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

MudBlazorConfig.ConfigureMudBlazor(builder.Services);
builder.Services.AddSingleton<ThemeService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<string>("apiUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl!) });

await builder.Build().RunAsync();
