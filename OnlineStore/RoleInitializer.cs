using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Models;

namespace OnlineStore
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminUsername = "administrator";

            string adminPassword = "BwG3k849kDfRJrLH";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }

            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                User admin = new User() { UserName = adminUsername, Email = "admin@domail.com"};
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            else
            {
                User admin = await userManager.FindByNameAsync(adminUsername);
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}