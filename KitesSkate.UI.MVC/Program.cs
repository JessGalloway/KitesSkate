using KitesSkate.UI.MVC.Data;
using KitsSkate.DATA.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KitesSkate.UI.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            //UI Layer
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //Add DbContext
            builder.Services.AddDbContext<KitesSkateContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //**********************************************    UPDATED builder.Services UPDATED   ****************************************************
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddRoleManager<RoleManager<IdentityRole>>().AddEntityFrameworkStores<ApplicationDbContext>();

            //OLD BUILDER SERVICES
            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddControllersWithViews();

            //Shopping Cart - Step 1 
            //Register Session -> MUST go after .AddControllersWithViews()
            //-After this, add app.UseSession() after routing

            builder.Services.AddSession(options => 
            {
                
                options.IdleTimeout= TimeSpan.FromMinutes(20);//howl long session will be active
                options.Cookie.HttpOnly = true;//allows cookies options to be set
                options.Cookie.IsEssential = true;//if you wish to use site must allow cookies
            
            });



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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}