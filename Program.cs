using Mahara.Data;
using Mahara.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===== Add services =====
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ===== Check database connection & seed default skills =====
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Check if test user exists
    if (userManager.FindByEmailAsync("test@test.com").Result == null)
    {
        var user = new ApplicationUser
        {
            UserName = "test@test.com",
            Email = "test@test.com",
            FullName = "Test User"
        };
        var result = userManager.CreateAsync(user, "Test123!").Result; // Password must meet Identity rules
        if (result.Succeeded)
        {
            Console.WriteLine("Test user created!");
        }
    }
}


// ===== Middleware =====
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ===== Routing =====
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
