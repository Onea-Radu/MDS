using EmagClone.Entities;
using EmagClone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OldIronIronWeTake.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<User> manager;
        private FavoritesService favoritesService;
        private CartService cartService;
        private ProductService products;
        private readonly ApplicationDbContext context;

        public UsersController(UserManager<User> userManager, ProductService products, FavoritesService favoritesService, CartService cart, ApplicationDbContext context)
        {
            this.manager = userManager;
            this.favoritesService = favoritesService;
            cartService = cart;
            this.products = products;
            this.context = context;
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
            return View(cartService.GetAll(user));
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
                bool check = favoritesService.AddToFavorites(id, user);
                Debug.Assert(check);
                if (!check)
                {
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
            var check = favoritesService.RemoveFromFavorites(id);
            Debug.Assert(favoritesService.RemoveFromFavorites(id));
            if (!check)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Favorites));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(Guid id)
        {
            User user = context.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            context.SaveChanges();
            return true;

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<bool> changeAuthorizationAsync(int id)
        {
            User user = context.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            if ((await manager.GetRolesAsync(user)).Contains("Store"))
            {
                await manager.RemoveFromRoleAsync(user, "Store");
            }
            else
            {
                await manager.AddToRoleAsync(user, "Store");
            }

            return true;
        }

    }
}