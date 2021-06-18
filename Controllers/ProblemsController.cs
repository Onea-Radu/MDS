using EmagClone.Entities;
using EmagClone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmagClone.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly ProblemService service;
        private readonly UserManager<User> manager;


        public ProblemsController(ProblemService service, UserManager<User> manager)
        {
            this.service = service;
            this.manager = manager;
        }

        // GET: Problems
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var all = service.GetAll();
            return View(all);
        }

        [Authorize(Roles = "User,Store,Admin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Store,Admin")]
        public async Task<IActionResult> Create([Bind("Text")] Problem problem)
        {
            problem.User = await manager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                service.Add(problem);
                ViewBag.msg = "Notice submitted successfully. Thank you!";
                return View();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (service.Delete(id))
                return RedirectToAction(nameof(Index));
            return NotFound();
        }
    }
}
