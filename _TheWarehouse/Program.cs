

using MySql.Data.EntityFramework;
using NHibernate.Criterion;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheWarehouse.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));*/

var warehouseConnectionString = builder.Configuration.GetConnectionString("WarehouseDB") ?? throw new InvalidOperationException("Connection string 'WarehouseDB' not found.");

/*
builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseMySQL(warehouseConnectionString, ));
*/
DbConfiguration.SetConfiguration(new MySqlEFConfiguration());


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WarehouseDbContext>();
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
