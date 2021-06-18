using EmagClone.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;

        public CartService(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public List<CartProductsUsers> GetAll(User user)
        {
            return context.CartProductsUsers.Where(u => u.User == user).ToList();
        }

        //maybe do it with product id
        public bool AddToCart(int pid, User user)
        {
            try
            {
                var prod = new CartProductsUsers { Product = context.Products.Find(pid), User = user };
                context.CartProductsUsers.Add(prod);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveFromCart(int id)
        {
            try
            {
                var prod = context.CartProductsUsers.Find(id);
                context.CartProductsUsers.Remove(prod);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
