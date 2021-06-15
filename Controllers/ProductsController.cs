using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmagClone.Entities;
using OldIronIronWeTake.Data;
using EmagClone.Services;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace EmagClone.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService service;
        private readonly UserManager<User> manager;
        public ProductsController(ProductService service, UserManager<User> manager)
        {
            this.service = service;
            this.manager = manager;
        }

        // GET: Products
        public async Task<IActionResult> Index(string keyword)
        {
            if (keyword == null || keyword == "")
            {
                return View(service.GetAll());
            }

            return View(service.Search(keyword));

        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = service.Get((int)id);
            //Debug.WriteLine("ceva string" + product.SellerId);
            //Debug.WriteLine("ceva string 2 " + product.Seller == null);
            //Debug.WriteLine("ceva string 3 " + product.Seller.UserName);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.SellerId = (await manager.GetUserAsync(HttpContext.User)).Id;
                service.Post(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = service.Get((int)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Stock,SellerId")] Product product)
        { 

            if (ModelState.IsValid)
            {
                if (!service.Update(product, (int)id))
                {
                    return NotFound();
                }
                
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }


        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (!service.Delete(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
