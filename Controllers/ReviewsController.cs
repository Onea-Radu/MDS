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

namespace EmagClone.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ReviewService service;
        private readonly UserManager<User> manager;

        public ReviewsController(ReviewService service, UserManager<User> manager)
        {
            this.service = service;
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? ProductId)
        {
            if (ProductId == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = (int)ProductId;
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Text,ProductId")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.User = await manager.GetUserAsync(HttpContext.User);
                service.Post(review);
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        //// GET: Reviews/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Reviews.FindAsync(id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", review.ProductId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
        //    return View(review);
        //}

        //// POST: Reviews/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Text,ProductId,UserId")] Review review)
        //{
        //    if (id != review.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(review);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReviewExists(review.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", review.ProductId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
        //    return View(review);
        //}

        //// GET: Reviews/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Reviews
        //        .Include(r => r.Product)
        //        .Include(r => r.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(review);
        //}

        //// POST: Reviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var review = await _context.Reviews.FindAsync(id);
        //    _context.Reviews.Remove(review);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ReviewExists(int id)
        //{
        //    return _context.Reviews.Any(e => e.Id == id);
        //}
    }
}
