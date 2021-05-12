using EmagClone.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OldIronIronWeTake.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid,
                    IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
                    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        public DbSet<Product> Products { get; set; }

    }
}
