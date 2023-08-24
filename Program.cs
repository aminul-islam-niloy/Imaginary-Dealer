using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Im_Dealer_DB_Contex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ID_Default_server") ?? throw new InvalidOperationException("Connection string 'ID_Default_server' not found.")));
//builder.Services.AddScoped<ProductManager>();
//builder.Services.AddScoped<Brand>();


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
