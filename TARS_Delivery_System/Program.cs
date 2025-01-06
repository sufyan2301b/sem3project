using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TARS_Delivery_System.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Tars_EprojectDbContext>(optons => 
optons.UseSqlServer(builder.Configuration.GetConnectionString("TARS_Delivery_System")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options=>options.Password.RequiredLength = 8
    ).AddEntityFrameworkStores<Tars_EprojectDbContext>() .AddDefaultTokenProviders();

builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Acccount/Login";
        options.AccessDeniedPath = "/Home/Index";
    }
    );

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRoles(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) 
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
