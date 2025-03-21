﻿using Identity.Constants;
using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service) {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();

            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //Admin creation

            var user = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Ashish",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userInDb = await userManager.FindByEmailAsync(user.Email);

            if (userInDb == null) {

                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());

            }

        }



    }
}
