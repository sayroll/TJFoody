global using TJFoody.Shared;
global using System.Net.Http.Json;
global using TJFoody.Client.Services.SellerService;
global using TJFoody.Client.Services.UserService;
global using TJFoody.Client.Services.ReviewService;
global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
global using TJFoody.Client.Services.TeamService;
global using TJFoody.Client.Services.CuisineService;
global using TJFoody.Client.Services.UserJoinTeamService;
global using TJFoody.Client.Services.PostService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TJFoody.Client;


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
builder.Services.AddScoped<IUserJoinTeamService,UserJoinTeamService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();

builder.Services.AddBootstrapBlazor();
await builder.Build().RunAsync();
