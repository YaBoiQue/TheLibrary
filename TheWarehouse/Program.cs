using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TheWarehouse.Data;

var builder = WebApplication.CreateBuilder(args);

// Test if local or docker connection string
string identityConnectionString;
string harnessConnectionString;
try
{
    identityConnectionString = builder.Configuration.GetConnectionString("LocalIdentityConnection") ?? throw new InvalidOperationException("Connection string 'LocalIdentityConnection' not found.");
    ServerVersion.AutoDetect(identityConnectionString);

    harnessConnectionString = builder.Configuration.GetConnectionString("LocalWarehouseConnection") ?? throw new InvalidOperationException("Connection string 'LocalWarehouseConnection' not found.");
    ServerVersion.AutoDetect(harnessConnectionString);
}
catch
{
    identityConnectionString = builder.Configuration.GetConnectionString("DockerIdentityConnection") ?? throw new InvalidOperationException("Connection string 'DockerIdentityConnection' not found.");

    identityConnectionString = builder.Configuration.GetConnectionString("DockerWarehouseConnection") ?? throw new InvalidOperationException("Connection string 'DockerWarehouseConnection' not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(identityConnectionString, ServerVersion.AutoDetect(identityConnectionString), o => {
        o.MigrationsHistoryTable(
            tableName: HistoryRepository.DefaultTableName,
            schema: "Identity");
        o.SchemaBehavior(MySqlSchemaBehavior.Ignore);
        o.EnableRetryOnFailure();
    }));

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
