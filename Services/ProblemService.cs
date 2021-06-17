using EmagClone.Entities;
using Microsoft.EntityFrameworkCore;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Services
{
    public class ProblemService
    {
        ApplicationDbContext context;

        public ProblemService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Problem> GetAll()
        {
            return context.Problems.Include(p => p.User).ToList();
        }


        public bool Add(Problem prob)
        {

            try
            {
                context.Add(prob);
                context.SaveChanges();
            }
            catch (Exception) { return false; }
            return true;
        }



        public bool Delete(int id)
        {
            try
            {
                var problem = context.Problems.Find(id);
                if (problem == null)
                    return false;
                context.Problems.Remove(problem);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }




    }
}
