using EventiaWebapp.Data;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EventsService>();
builder.Services.AddScoped<DataBase>();

var connectionString = 
"server=(localdb)\\MSSQLLocalDB;" +
"Database=EventiaDB";

builder.Services
    .AddDbContext<EventiaDbContext>(
        options =>
        {
            options.UseSqlServer(connectionString);
        });
    

var app = builder.Build();

app.UseStaticFiles();

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

app.Run();
