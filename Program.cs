using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CJ.Data;
using CJ.Models;
using CJ.Repository;
using CJ.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CJDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSingleton<IGetData, GetData>();
builder.Services.AddScoped<IAddData, AddData>();
builder.Services.AddSingleton<IUpdateData, UpdateData>();
//builder.Services.AddSingleton<IDeleteData, DeleteData>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "articlesRoute",
    pattern: "Articles/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
