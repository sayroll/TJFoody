global using TJFoody.Server.Service.SellerService;
global using TJFoody.Shared;
global using CLRForBlazor;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore; 
using TJFoody.Server.Models;
using TJFoody.Server.Hubs;
using TJFoody.Server.Service.CuisineService;
using TJFoody.Server.Service.ReviewService;
using TJFoody.Server.Service.TeamService;
using TJFoody.Server.Service.UserService;
using TJFoody.Server.Service.PostService;
using TJFoody.Server.Service.CommentService;
using TJFoody.Server.Service.UserJoinTeamService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<infoContext>(options=> options.UseMySql(builder.Configuration.GetConnectionString("Default"), ServerVersion.Parse("5.7.18-mysql")));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICuisineService, CuisineService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserJoinTeamService, UserJoinTeamService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
         new[] { "application/octet-stream" });
});

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.MapFallbackToFile("index.html");

app.Run();
