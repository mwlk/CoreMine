using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CoreMine.Client;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<CoreMine.Client.Services.ThemeService>();

builder.Services.AddRadzenComponents().AddRadzenComponents();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<string>("apiUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl!) });

await builder.Build().RunAsync();
