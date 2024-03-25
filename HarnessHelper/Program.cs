using HarnessHelper.Areas.Identity.Models;
using HarnessHelper.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string connectionString;
try
{
    connectionString = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");
    ServerVersion.AutoDetect(connectionString);
}
catch
{
    connectionString = builder.Configuration.GetConnectionString("LocalIdentityConnection") ?? throw new InvalidOperationException("Connection string 'LocalIdentityConnection' not found.");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o => {
        o.MigrationsHistoryTable(
            tableName: HistoryRepository.DefaultTableName,
            schema: "Identity");
        o.SchemaBehavior(MySqlSchemaBehavior.Ignore);
        o.EnableRetryOnFailure();
    }));

try
{
    connectionString = builder.Configuration.GetConnectionString("HarnessConnection") ?? throw new InvalidOperationException("Connection string 'HarnessConnection' not found.");
    ServerVersion.AutoDetect(connectionString);
}
catch
{
    connectionString = builder.Configuration.GetConnectionString("LocalHarnessConnection") ?? throw new InvalidOperationException("Connection string 'LocalHarnessConnection' not found.");
}
builder.Services.AddDbContext<HarnessDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o => {
        o.MigrationsHistoryTable(
            tableName: HistoryRepository.DefaultTableName,
            schema: "Harness");
        o.SchemaBehavior(MySqlSchemaBehavior.Ignore);
        o.EnableRetryOnFailure();
    }));


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
