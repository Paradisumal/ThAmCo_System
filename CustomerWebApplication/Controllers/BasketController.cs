using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Web.Services.Basket;
using Customer.Web.Services.Product;
using Customer.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ILogger _logger;
        private readonly IBasketFacade _basketFacade;
        private readonly IProductFacade _productFacade;

        public BasketController(ILogger<BasketController> logger,
                                IBasketFacade basketFacade,
                                IProductFacade productFacade)
        {
            _logger = logger;
            _basketFacade = basketFacade;
            _productFacade = productFacade;
        }

        // GET : Basket
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<BasketItemDto> basketItems = null;
            try
            {
                basketItems = await _basketFacade.GetBasket(1);
                /*basketItems = await _basketFacade.GetBasket(customerId);*/
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Basket Facade");
                basketItems = null;
            }

            IEnumerable<BasketItemViewModel> viewModel = basketItems.Select(b => new BasketItemViewModel
            {
                ProductId = b.ProductId,
                Name = b.ProductName,
                Quantity = b.Quantity,
                Price = b.Price
            });

            return View(viewModel);
        }

        // GET : Basket/AddItem/5
        [HttpGet]
        public async Task<IActionResult> AddItem([FromQuery] int ProductId)
        {
            ProductDto product = null;
            try
            {
                product = await _productFacade.GetProduct(ProductId);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Basket Facade");
                product = null;
            }

            BasketItemViewModel viewModel = new BasketItemViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                BrandId = product.BrandId,
                Brand = product.Brand,
                CategoryId = product.CategoryId,
                Category = product.Category,
                Price = product.Price
            };

            return View(viewModel);
        }

        // Post : Basket/AddItem/5
        [HttpPost]
        public async Task<IActionResult> AddItem([Bind("ProductId,Quantity")] BasketItemDto newItem)
        {
            try
            {
                await _basketFacade.AddItem(newItem);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Basket Facade");
            }

            return RedirectToAction("Items", "Products");
        }

        // Get : Basket/RemoveItem/
        [HttpGet]
        public async Task<IActionResult> RemoveItem([FromQuery] int ProductId)
        {
            try
            {
                await _basketFacade.RemoveItem(1, ProductId);
                /*await _basketFacade.RemoveItem(customerId, ProductId);*/
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Basket Facade");
            }

            return RedirectToAction("Items");
        }
    }
}