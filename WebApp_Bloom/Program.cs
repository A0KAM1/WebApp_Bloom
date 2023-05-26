using Microsoft.EntityFrameworkCore;
using WebApp_Bloom;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Contexto>(option =>

option.UseSqlServer("Server=201.55.32.20;Database=BLOOM;User Id=pw_tarde;Password=aluno123;"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
