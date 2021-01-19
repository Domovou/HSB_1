using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = {"Admin", "User"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));

                }
            }

            var _admin = await UserManager.FindByEmailAsync("admin@admin.com");
            if (_admin == null)
            {
                var admin = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                var createAdmin = await UserManager.CreateAsync(admin, "Admin2019!");
                if (createAdmin.Succeeded)
                    await UserManager.AddToRoleAsync(admin, "Admin");
            }

            var _user = await UserManager.FindByEmailAsync("user@user.com");
            if (_user == null)
            {
                var user = new IdentityUser
                {
                    UserName = "user@user.com",
                    Email = "user@user.com"
                };

                var createUser = await UserManager.CreateAsync(user, "User2019!");
                if (createUser.Succeeded)
                   await  UserManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
