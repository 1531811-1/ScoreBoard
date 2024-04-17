using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CatalogueJeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogueJeuDbContextConnection"]));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");




app.Run();
