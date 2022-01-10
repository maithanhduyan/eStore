using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the EF Core SchoolContext
builder.Services.AddDbContext<ApllicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationContextSQLite")));

// builder.Services.AddDbContext<ApllicationContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationContextPostgreSQL")));

// builder.Services.AddDbContext<ApllicationContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContextSQLServer")));

// builder.Services.AddDbContext<ApllicationContext>(options =>
// options.UseInMemoryDatabase(databaseName: "Test"));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApllicationContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
