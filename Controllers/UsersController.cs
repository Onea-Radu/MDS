using EmagClone.Entities;
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
    }
}
