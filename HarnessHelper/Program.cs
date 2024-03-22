using HarnessHelper.Areas.Identity.Models;
using HarnessHelper.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string connectionString;
try
{
    connectionString = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    ServerVersion.AutoDetect(connectionString);
}
catch
{
    connectionString = builder.Configuration.GetConnectionString("LocalIdentityConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<Aspnetuser, Aspnetrole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
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
