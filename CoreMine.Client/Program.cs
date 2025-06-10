using Blazored.LocalStorage;
using CoreMine.Client;
using CoreMine.Client.Authtentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<CoreMine.Client.Services.ThemeService>();

builder.Services.AddRadzenComponents();

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<AuthService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<string>("apiUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl!) });

await builder.Build().RunAsync();
