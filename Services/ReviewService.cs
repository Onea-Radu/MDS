using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmagClone.Entities;
using Microsoft.EntityFrameworkCore;
using OldIronIronWeTake.Data;

namespace EmagClone.Services
{
    public class ReviewService
    {

        private readonly ApplicationDbContext context;

        public ReviewService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Review> GetAll()
        {
            return context.Reviews.ToList();
        }

        public Review Get(int id)
        {
            var x = context.Reviews.Where(p => p.Id == id);
            if (!x.Any())
            {
                return null;
            }
            return x.First();
        }

        public bool Post(Review review)
        {
            //if (ProductId == null || user == null)
            //{
            //    return false;
            //}
            //var review = new Review { Product = context.Products.Find((int)ProductId), User = user };

            if(review == null)
            {
                return false;
            }

            Debug.WriteLine(review.Text);
            Debug.WriteLine(review.ProductId);

            context.Reviews.Add(review);
            context.SaveChanges();
            return true;
        }

        public bool Update(Review review, int id)
        {
            if (review == null || id != review.Id)
            {
                return false;
            }

            try
            {
                Review reviewContext = context.Reviews.Find(id);


                if (reviewContext == null)
                {
                    return false;
                }

                reviewContext.Text = review.Text;

                context.SaveChanges();

            }
            catch (Exception e) { return false; }
            return true;
        }

        public bool Delete(int id)
        {

            Review review = context.Reviews.Find(id);
            if (review == null)
            {
                return false;
            }

            context.Remove(review);
            context.SaveChanges();
            return true;

        }

    }
}
