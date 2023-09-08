using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Imaginary_Dealer.Data;
using vroom.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Im_Dealer_DB_Contex>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ID_Default_server") ?? throw new InvalidOperationException("Connection string 'ID_Default_server' not found.")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Im_Dealer_DB_Contex>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
//builder.Services.AddScoped<IDbInitializer>();


builder.Services.AddScoped<IDbInitializer, DBInitializer>();



var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var dbInitializer = services.GetRequiredService<IDbInitializer>();
//    dbInitializer.Initialize(); // Call your database seeding logic here
//}


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

app.MapRazorPages();
app.Run();
