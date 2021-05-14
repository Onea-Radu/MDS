using EmagClone.Entities;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Services
{
    public class ProductService
    {

        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public bool Post( String name, Guid userId )
        {

            User user = context.Users.Find(userId);
            
            if (user == null)
            {
                return false;
            }

            context.Products.Add(new Product { Name = name, Seller = user });
            context.SaveChanges();
            return true;
        }

        public bool Update( String nume, int id)
        {
            Product product = context.Products.Find(id);

            if ( product == null )
            {
                return false;
            }

            product.Name = nume;
            context.SaveChanges();
            return true;
        }

        public bool Update(Guid sellerId, int id)
        {
            Product product = context.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            product.SellerId = sellerId;
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            context.Remove(product);
            context.SaveChanges();
            return true;

        }

    }
}
