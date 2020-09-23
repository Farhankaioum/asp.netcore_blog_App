using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Seeder
{
    public enum Roles
    {
        SuperAdmin,
        Admin,
        Moderator,
        Basic
    }
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // seed roles
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Default User
            var defaultUser1 = new IdentityUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var defaultUser2 = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser1.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser1, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser1, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser1, Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser1, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser1, Roles.SuperAdmin.ToString());

                    await userManager.CreateAsync(defaultUser2, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser2, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser2, Roles.Moderator.ToString());

                }
            }
        }
    }
}
