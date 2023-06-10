global using TJFoody.Server.Service.SellerService;
global using TJFoody.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore; 
using TJFoody.Server.Models;
using TJFoody.Server.Service.CuisineService;
using TJFoody.Server.Service.ReviewService;
using TJFoody.Server.Service.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<infoContext>(options=> options.UseMySql(builder.Configuration.GetConnectionString("Default"), ServerVersion.Parse("5.7.18-mysql")));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICuisineService, CuisineService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

var app = builder.Build();

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
app.MapFallbackToFile("index.html");

app.Run();
