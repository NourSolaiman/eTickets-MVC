using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace eTickets
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Get Configuration from app settings
            var Configuration = builder.Configuration;

            //DbContext configuration
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            //Identity function configuration
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

          
            //Service configure,Registring Service
            builder.Services.AddScoped<IActorsService, ActorsService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Identity part
            app.UseAuthentication();

            app.UseAuthorization();
            
            



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Seed app database
            AppDbInitializer.Seed(app);

            // Seeding Admin/User info
            using(var scope=app.Services.CreateScope()) 
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Manager", "User" };
                 foreach (var role in roles) 
                 {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                 }
            }

            using(var scope = app.Services.CreateScope()) 
            {  
                var userManager=scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                
               //seting default value for admin account 
                string email = "BojanAdmin";
                string password = "Bojan1981!";

                if (await userManager.FindByEmailAsync(email)==null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;

                    //Creating Admin User
                    await userManager.CreateAsync(user, password);

                    //Put the User to his Admin Role
                    await userManager.AddToRoleAsync(user, "Admin");

                }
            }


            app.Run();
        }
    }
}