global using TJFoody.Shared;
global using System.Net.Http.Json;
global using TJFoody.Client.Services.SellerService;
global using TJFoody.Client.Services.UserService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TJFoody.Client;
using TJFoody.Client.Services.CuisineService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after"); 

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ICuisineService, CuisineService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddBootstrapBlazor();
await builder.Build().RunAsync();
