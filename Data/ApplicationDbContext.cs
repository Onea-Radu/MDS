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

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CartProductsUsers>()
            //.HasOne(c => c.Product)
            //.WithMany()
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<CartProductsUsers>()
            //.HasOne(c => c.User)
            //.WithMany()
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<FavoriteProductsUsers>()
            //.HasOne(c => c.User)
            //.WithMany()
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<FavoriteProductsUsers>()
            //.HasOne(c => c.Product)
            //.WithMany()
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Review>()
            //.HasOne(c => c.User)
            //.WithMany()
            //.OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<FavoriteProductsUsers>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.favoriteProducts)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<FavoriteProductsUsers>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.favoriteProducts)
                .HasForeignKey(bc => bc.ProductId);


            modelBuilder.Entity<CartProductsUsers>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.cartProducts)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<CartProductsUsers>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.cartProducts)
                .HasForeignKey(bc => bc.ProductId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<FavoriteProductsUsers> FavoriteProductsUsers { get; set; }
        public DbSet<CartProductsUsers> CartProductsUsers { get; set; }

    }
}
