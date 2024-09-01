using AtulaDotNetTest.Data;
using AtulaDotNetTest.Domain;
using AtulaDotNetTest.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Connection strings
var appConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var authConnectionString = builder.Configuration.GetConnectionString("AuthConnection");

// Register WebAppContext with the AppConnection string
builder.Services.AddDbContext<WebAppContext>(options =>
    options.UseMySql(appConnectionString, ServerVersion.AutoDetect(appConnectionString))
);

// Register UsersDbContext for ASP.NET Core Identity
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseMySql(authConnectionString, ServerVersion.AutoDetect(authConnectionString)));

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<UsersDbContext>()
.AddDefaultTokenProviders();

// Configure authentication and authorization
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();