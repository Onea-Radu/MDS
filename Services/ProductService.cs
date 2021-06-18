using EmagClone.Entities;
using Microsoft.EntityFrameworkCore;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return context.Products.Include("Seller").ToList();
        }
        public List<Product> GetByUser(Guid user)
        {
            var lista = context.Products.Include("Seller").Where(p => p.Seller.Id == user).ToList();
            Debug.WriteLine(user);
            foreach(var item in context.Products)
            {
                Debug.WriteLine(item.SellerId);
            }
            Debug.WriteLine(lista.Count);
            return lista;
        }
        public IEnumerable<Product> Search(string keyword)
        {
            return GetAll().Where(p => p.Name.Contains(keyword));
        }

        public Product Get(int id)
        {
            var x = context.Products.Include("Seller").Where(p => p.Id == id);
            if (!x.Any())
            {
                return null;
            }
            return x.First();
        }

        public bool Post(Product product)
        {

            if (product == null)
            {
                return false;
            }

            context.Products.Add(product);
            context.SaveChanges();
            return true;
        }

        public bool Update(Product product, int id)
        {
            if (product == null || id != product.Id)
            {
                return false;
            }

            try
            {
                Product productContext = context.Products.Find(id);


                if (productContext == null)
                {
                    return false;
                }

                productContext.Stock = product.Stock;
                productContext.Name = product.Name;

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

            context.Products.Remove(product);
            context.SaveChanges();
            return true;

        }

    }
}
