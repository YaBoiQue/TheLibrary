using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityController.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString;
try
{
    connectionString = builder.Configuration.GetConnectionString("LocalDefaultConnection") ?? throw new InvalidOperationException("Connection string 'LocalWarehouseDb' not found.");
    ServerVersion.AutoDetect(connectionString);
}
catch
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'LocalWarehouseDb' not found.");
}
builder.Services.AddDbContext<ApplicationDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
