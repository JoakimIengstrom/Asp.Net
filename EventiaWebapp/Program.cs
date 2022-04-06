using EventiaWebapp.Data;
using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EventsService>();
builder.Services.AddScoped<DataBase>();

var connectionString = 
"server=(localdb)\\MSSQLLocalDB;" +
"Database=EventiaPartTwoDBContext";

builder.Services
    .AddDbContext<EventiaPartTwoDBContext>(
        options =>
        {
            options.UseSqlServer(connectionString);
        });

builder.Services.AddDefaultIdentity<EventiaUser>(options => options.SignIn.RequireConfirmedAccount = false) //All IdenityUser becomes User. 
    .AddEntityFrameworkStores<EventiaPartTwoDBContext>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "event",
    pattern: "{controller=Event}/{action=JoinEvent}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dataBase = scope.ServiceProvider.GetService<DataBase>();
    dataBase.PrepDatabase();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
