using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace Gestion_Projet_App.Extensions
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Création du rôle administrateur
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Création de l'utilisateur administrateur
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin123@";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail, Address ="kelaa des sraghnna", FirstName = "Admin",LastName ="Khouy" };
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
