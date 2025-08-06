using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PokemonLite.Persistance.Implementations;

namespace PokemonLite.Persistance.Seed;

public static class IdentitySeed
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        string[] roles = ["Admin", "Trainer"];

        foreach (var role in roles)
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

        var adminEmail = "admin@admin.com";
        var adminPassword = "Admin123";

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new User
            {
                UserName = "admin",
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded) await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}