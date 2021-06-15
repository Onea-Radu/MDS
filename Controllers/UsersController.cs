using EmagClone.Entities;
using EmagClone.Services;
using Microsoft.AspNetCore.Authorization;
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
        private CartService cartService;

        public UsersController(UserManager<User> userManager, FavoritesService favoritesService, CartService cart)
        {
            this.manager = userManager;
            this.favoritesService = favoritesService;
            cartService = cart;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            return View();
        }

        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> Cart()
        {
            var user = (await manager.GetUserAsync(HttpContext.User));
            return View(favoritesService.GetAll(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> AddToCart(int id)
        {
            if (ModelState.IsValid)
            {
                var user = (await manager.GetUserAsync(HttpContext.User));
                if (!cartService.AddToCart(id, user))
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Cart));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            if (!cartService.RemoveFromCart(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> Order()
        {
            return View();
        }

        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> Favorites()
        {
            var user = (await manager.GetUserAsync(HttpContext.User));
            return View(favoritesService.GetAll(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> AddFavorite(int id)
        {
            if (ModelState.IsValid)
            {
                var user = (await manager.GetUserAsync(HttpContext.User));
                if (!favoritesService.AddToFavorites(id, user)) {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Favorites));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            if (!favoritesService.RemoveFromFavorites(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Favorites));
        }
    }
}