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


        public InitialSeeder(ApplicationDbContext context)
        {
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
        }
    }
}
