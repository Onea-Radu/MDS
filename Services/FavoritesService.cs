using EmagClone.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmagClone.Services
{
    public class FavoritesService
    {
        private readonly ApplicationDbContext context;


        public FavoritesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<FavoriteProductsUsers> GetAll(User user)
        {
            return context.FavoriteProductsUsers.Include("Product").Where(u => u.User == user).ToList();
        }

        //maybe do it with product id
        public bool AddToFavorites(int pid, User user)
        {
            try
            {
                if (context.FavoriteProductsUsers.Find(pid) == null)
                {
                    var prod = new FavoriteProductsUsers { Product = context.Products.Find(pid), User = user };
                    context.FavoriteProductsUsers.Add(prod);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveFromFavorites(int id)
        {
            try
            {
                var prod = context.FavoriteProductsUsers.Find(id);
                context.FavoriteProductsUsers.Remove(prod);
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
