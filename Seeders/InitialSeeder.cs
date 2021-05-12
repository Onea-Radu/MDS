using EmagClone.Entities;
using Microsoft.AspNetCore.Identity;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace EmagClone.Seeders
{
    public class InitialSeeder : ISeeder
    {

        private readonly ApplicationDbContext context;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;




        public InitialSeeder(ApplicationDbContext context, UserManager<User> userManager)
        {

            this.userManager = userManager;
            this.context = context;
        }

        public void Seed()
        {
            Debug.WriteLine($"Salve");
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Role { Name = "Admin" });
                context.Roles.Add(new Role { Name = "Store" });
                context.Roles.Add(new Role { Name = "User" });
                context.SaveChanges();
            }
            //if (!context.Products.Any())
            //{
            //    context.Products.Add(new Product { Name = "Banane", SellerId = userManager.Users.First().Id });
            //    context.SaveChanges();
            //}

        }
    }
}
