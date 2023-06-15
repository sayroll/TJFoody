global using TJFoody.Shared;
global using System.Net.Http.Json;
global using TJFoody.Client.Services.SellerService;
global using TJFoody.Client.Services.UserService;
global using TJFoody.Client.Services.ReviewService;
global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
global using TJFoody.Client.Services.TeamService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TJFoody.Client;
using TJFoody.Client.Services.CuisineService;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ICuisineService, CuisineService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();

builder.Services.AddBootstrapBlazor();
await builder.Build().RunAsync();
