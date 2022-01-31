using EStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EStore.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

EStore.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Services Dependency Injection
builder.Services.AddCoreServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Create Database
using (var scope = app.Services.CreateScope())
{
    bool _isCreatedDataSample = Boolean.Parse(builder.Configuration.GetSection("CreateDatabaseSample").Value);
    Console.WriteLine("Databse Sample " + _isCreatedDataSample);
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();

    if (context.Database.EnsureCreated())
    {
        if (_isCreatedDataSample)
        {
            // Data Sample
            await DbInitializer.InitializeAsync(context);
        }
    }

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
