using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database
{
    public static class IdentityDbInitializer
    {
        public static async Task Initialize(WalletDbContext context, UserManager<UserRecord> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var admin = await AddUser(userManager, roleManager, "admin@gmail.com", "Qwe123!", "admin");
            var user = await AddUser(userManager, roleManager, "user@gmail.com", "Qwe123!", "user");
        }
    
        private static async Task<UserRecord> AddUser(UserManager<UserRecord> userManager, RoleManager<IdentityRole> roleManager,
            string email, string password, string role)
        {
            if (await roleManager.FindByNameAsync(role) == null)
                await roleManager.CreateAsync(new IdentityRole(role));

            var user = await userManager.FindByNameAsync(email);
            if (user != null) return user;

            user = new UserRecord {Email = email, UserName = email};
            if ((await userManager.CreateAsync(user, password)).Succeeded)
                await userManager.AddToRoleAsync(user, role);
            return user;
        }
    }
}