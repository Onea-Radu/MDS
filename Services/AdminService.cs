using EmagClone.Entities;
using Microsoft.AspNetCore.Identity;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EmagClone.Services
{
    public class AdminService
    {

        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;

        public AdminService(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }



    }
}
