using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Review;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApplication.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review/Create/5
        public IActionResult Create(int id)
        {
            return View();
        }

        // POST: Review/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewDto review)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details","Product", review.ProductId);
            }

            return View(review);
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewDto Review)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", id);
            }

            return View();
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction("History");
        }

        // GET: Review/History
        public async Task<IActionResult> History()
        {
            return View();
        }
    }
}