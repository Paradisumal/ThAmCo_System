using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Product;
using Customer.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductFacade _ProductFacade;

        public ProductController(ILogger<ProductController> logger,
                                IProductFacade productFacade)
        {
            _logger = logger;
            _ProductFacade = productFacade;
        }

        // GET : Product
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET : Product/Categories
        public async Task<IActionResult> Categories()
        {
            ProductInfoDto productInfo = null;

            return View(productInfo);
        }

        // GET : Product/Brands
        public async Task<IActionResult> Brands()
        {
            ProductInfoDto productInfo = null;

            return View(productInfo);
        }

        // GET : Product/Filter
        public async Task<IActionResult> Filter()
        {
            ProductInfoDto productInfo = null;

            return View(productInfo);
        }

        /*// Post : Product/Filter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter()
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }*/

        // GET: Product/Search
        public async Task<IActionResult> Search()
        {
            return View();
        }

        /*// POST: Product/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search()
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }*/

        // GET: Product/List
        public async Task<IActionResult> Catalogue()
        {
            return View();
        }

        // GET : Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}