using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Web.Services.Review;
using Customer.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerWebApplication.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReviewFacade _reviewFacade;

        public ReviewController(ILogger<ReviewController> logger,
                                IReviewFacade reviewFacade)
        {
            _logger = logger;
            _reviewFacade = reviewFacade;
        }

        // GET: Review/5
        public async Task<IActionResult> Index(int productId, string productName)
        {
            IEnumerable<ReviewDto> reviews = null;
            try
            {
                reviews = await _reviewFacade.GetProductReviews(productId);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                reviews = null;
            }

            IEnumerable<ReviewViewModel> viewModel = reviews.Select(r => new ReviewViewModel
            {
                CustomerName = r.CustomerName,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                Timestamp = r.Timestamp
            });

            ViewData["ProductId"] = productId;
            ViewData["ProductName"] = productName;

            return View(viewModel);
        }

        // GET: Review/Create/5
        public IActionResult Create([FromQuery] int ProductId,
                                    [FromQuery] string ProductName)
        {
            ReviewViewModel viewModel = new ReviewViewModel
            {
                ProductId = ProductId,
                ProductName = ProductName
            };

            return View(viewModel);
        }

        // POST: Review/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel Review)
        {
            if (ModelState.IsValid)
            {
                ReviewDto updatedReview = new ReviewDto
                {
                    CustomerId = 1,
                    /*CustomerId = customerId,*/
                    CustomerName = "Carter",
                    /*CustomerName = customerName,*/
                    ProductId = Review.ProductId,
                    ProductName = Review.ProductName,
                    Timestamp = DateTime.Now,
                    Rating = Review.Rating,
                    ReviewText = Review.ReviewText
                };

                try
                {
                    await _reviewFacade.NewReview(updatedReview);
                }
                catch (HttpRequestException)
                {
                    _logger.LogWarning("Exception Occured using Review Facade");
                }

                return RedirectToAction("History","Order");
            }

            return View(Review);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit([FromQuery] int ProductId,
                                              [FromQuery] string ProductName,
                                              [FromQuery] int Rating,
                                              [FromQuery] string ReviewText)
        {
            ReviewViewModel viewModel = new ReviewViewModel
            {
                ProductId = ProductId,
                ProductName = ProductName,
                Rating = Rating,
                ReviewText = ReviewText
            };

            return View(viewModel);
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReviewViewModel Review)
        {
            if (ModelState.IsValid)
            {
                ReviewDto updatedReview = new ReviewDto
                {
                    CustomerId = 1,
                    /*CustomerId = customerId,*/
                    CustomerName = "Carter",
                    /*CustomerName = customerName,*/
                    ProductId = Review.ProductId,
                    Timestamp = DateTime.Now,
                    Rating = Review.Rating,
                    ReviewText= Review.ReviewText
                };

                try
                {
                    await _reviewFacade.EditReview(updatedReview);
                }
                catch (HttpRequestException)
                {
                    _logger.LogWarning("Exception Occured using Review Facade");
                }
               
                return RedirectToAction("History", "Review");
            }

            return View(Review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int ProductId)
        {
            ViewData["ProductId"] = ProductId;

            return View();
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductId)
        {
            try
            {
                await _reviewFacade.DeleteReview(1, ProductId);
                /*await _reviewFacade.DeleteReview(customerId, ProductId);*/
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Review Facade");
            }

            return RedirectToAction("History");
        }

        // GET: Review/History
        public async Task<IActionResult> History()
        {
            IEnumerable<ReviewDto> reviewHistory = null;
            try
            {
                reviewHistory = await _reviewFacade.GetCustomerReviews(1);
                /*reviewHistory = await _reviewFacade.GetCustomerReviews(customerId);*/
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Review Facade");
                reviewHistory = null;
            }

            IEnumerable<ReviewViewModel> viewModel = reviewHistory.Select(r => new ReviewViewModel
            {
                Timestamp = r.Timestamp,
                ProductId = r.ProductId,
                ProductName = r.ProductName,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
            });

            return View(viewModel);
        }
    }
}