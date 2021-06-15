using EmagClone.Entities;
using EmagClone.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<User> manager;
        private FavoritesService favoritesService;

        public UsersController(UserManager<User> userManager, FavoritesService favoritesService)
        {
            this.manager = userManager;
            this.favoritesService = favoritesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            return View();
        }


        public async Task<IActionResult> Cart()
        {

            return View();
        }


        public async Task<IActionResult> Order()
        {
            return View();
        }

        public async Task<IActionResult> Favorites()
        {

            return View(manager);
        }
    }
}
