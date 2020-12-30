using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Web.Services.Product;
using Customer.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET : Product/Categories
        [AllowAnonymous]
        public async Task<IActionResult> Categories()
        {
            ProductInfoDto productInfo = null;
            try
            {
                productInfo = await _ProductFacade.GetCategoriesAndBrands();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                productInfo = null;
            }

            var viewModel = new CategoryListViewModel()
            {
                Categories = productInfo.Categories
            };

            return View(viewModel);
        }

        // GET : Product/ByCategory
        [AllowAnonymous]
        public async Task<IActionResult> ByCategory([FromQuery] int CategoryId)
        {
            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _ProductFacade.GetProductsByCategory(CategoryId);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                products = null;
            }

            IEnumerable<ProductViewModel> viewModel = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                BrandId = p.BrandId,
                Brand = p.Brand,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Price = p.Price
            });

            ViewData["Category"] = products.First().Category;

            return View(viewModel);
        }

        // GET : Product/Brands
        [AllowAnonymous]
        public async Task<IActionResult> Brands()
        {
            ProductInfoDto productInfo = null;
            try
            {
                productInfo = await _ProductFacade.GetCategoriesAndBrands();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                productInfo = null;
            }

            var viewModel = new BrandListViewModel()
            {
                Brands = productInfo.Brands
            };

            return View(viewModel);
        }

        // GET : Product/ByCategory
        [AllowAnonymous]
        public async Task<IActionResult> ByBrand([FromQuery] int BrandId)
        {
            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _ProductFacade.GetProductsByBrand(BrandId);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                products = null;
            }

            IEnumerable<ProductViewModel> viewModel = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                BrandId = p.BrandId,
                Brand = p.Brand,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Price = p.Price
            });

            ViewData["Brand"] = products.First().Brand;

            return View(viewModel);
        }

        // GET : Product/Filter
        [AllowAnonymous]
        public async Task<IActionResult> Filter()
        {
            ProductInfoDto productInfo = null;
            try
            {
                productInfo = await _ProductFacade.GetCategoriesAndBrands();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                productInfo = null;
            }

            var viewModel = new ProductFilterViewModel()
            {
                /*Categories = productInfo.Categories,
                Brands = productInfo.Brands,*/
            };

            ViewData["BrandId"] = new SelectList(productInfo.Brands, "BrandId", "Brand");
            ViewData["CategoryId"] = new SelectList(productInfo.Categories, "CategoryId", "Category");

            return View(viewModel);
        }

        // GET : Product/ByFilter
        [AllowAnonymous]
        public async Task<IActionResult> ByFilter([FromQuery] int CategoryId,
                                                   [FromQuery] int BrandId,
                                                   [FromQuery] double MinPrice,
                                                   [FromQuery] double MaxPrice)
        {
            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _ProductFacade.GetProductsByFilter(CategoryId, BrandId,
                                                                    MinPrice, MaxPrice);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                products = null;
            }

            IEnumerable<ProductViewModel> viewModel = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                BrandId = p.BrandId,
                Brand = p.Brand,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Price = p.Price
            });

            ViewData["Category"] = products.First().Category;
            ViewData["Brand"] = products.First().Brand;
            ViewData["CategoryId"] = MinPrice;
            ViewData["BrandId"] = MaxPrice;
            ViewData["MinPrice"] = MinPrice;
            ViewData["MaxPrice"] = MaxPrice;

            return View(viewModel);
        }

        // GET: Product/Search
        [AllowAnonymous]
        public async Task<IActionResult> Search()
        {
            return View();
        }

        // GET: Product/BySearch
        [AllowAnonymous]
        public async Task<IActionResult> BySearch(string SearchString)
        {
            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _ProductFacade.GetProductsBySearch(SearchString);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                products = null;
            }

            IEnumerable<ProductViewModel> viewModel = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Quantity = p.Quantity,
                BrandId = p.BrandId,
                Brand = p.Brand,
                CategoryId = p.CategoryId,
                Category = p.Category,
                Price = p.Price
            });

            ViewData["Category"] = products.First().Category;
            ViewData["Brand"] = products.First().Brand;
            ViewData["SearchString"] = SearchString;

            return View(viewModel);
        }

        // GET : Product/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int productId)
        {
            ProductDto product = null;
            try
            {
                product = await _ProductFacade.GetProduct(productId);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product Facade");
                product = null;
            }

            ProductViewModel viewModel = new ProductViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                BrandId = product.BrandId,
                Brand = product.Brand,
                CategoryId = product.CategoryId,
                Category = product.Category,
                Price = product.Price
            };

            return View(viewModel);
        }
    }
}