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

        public CartService(ApplicationDbContext context, UserManager<User> manager)
        {
            this.context = context;
            this.userManager = manager;
        }

        //public async bool AddtoCart(Product product)
        //{
        //    var id = (await userManager.GetUserAsync(User)).Id;
        //    var cart = new CartProductsUsers
        //    {
        //        Product = product,
        //        UserId = id;
        //    };
        //    context.CartProductsUsers.Add()

        //    return false;
        //}

    }
}
