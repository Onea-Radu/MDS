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

        public bool Post(String name, Guid userId)
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

        public bool Update(Product product, int id)
        {

            try
            {
                Product productContext = context.Products.Find(id);
                if (product == null)
                {
                    return false;
                }

                if (productContext == null)
                {
                    return false;
                }

                try
                {
                    productContext.Stock = product.Stock;
                    productContext.Name = product.Name;
                }

                catch (Exception e) { return false; }

                context.SaveChanges();

            }
            catch (Exception e) { return false; }
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
