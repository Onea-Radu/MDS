using EmagClone.Seeders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OldIronIronWeTake.Data;
using OldIronIronWeTake.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OldIronIronWeTake.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeeder seeder;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ISeeder seeder, ApplicationDbContext context)
        {
            this.context = context;
            _logger = logger;
            this.seeder = seeder;
        }

        public IActionResult Index()
        {
            seeder.Seed();
            Debug.WriteLine(context.Products.Select(p => p.Name));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
