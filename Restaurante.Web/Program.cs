using Restaurante.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<RestauranteDbContext>(option =>
{
    var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    var dbPath = Path.Combine(localAppData, "Restaurante.db");


    option.UseSqlite($"Data Source={dbPath}")
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information);
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<RestauranteDbContext>();

if (context.Database.GetPendingMigrations().Any())
    context.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
