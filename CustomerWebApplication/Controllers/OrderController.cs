using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Web.Services.Basket;
using Customer.Web.Services.Order;
using Customer.Web.Services.Review;
using Customer.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IOrderFacade _orderFacade;
        private readonly IBasketFacade _basketFacade;
        private readonly IReviewFacade _reviewFacade;

        public OrderController(ILogger<OrderController> logger,
                                IOrderFacade orderFacade,
                                IBasketFacade basketFacade,
                                IReviewFacade reviewFacade)
        {
            _logger = logger;
            _orderFacade = orderFacade;
            _basketFacade = basketFacade;
            _reviewFacade = reviewFacade;
        }

        // GET: Order
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

            IEnumerable<OrderedItemViewModel> orderedItems = basketItems.Select(b => new OrderedItemViewModel
            {
                ProductId = b.ProductId,
                Quantity = b.Quantity,
                Price = b.Price,
                ProductName = b.ProductName,
            });

            double totalPrice = 0;
            foreach (OrderedItemViewModel item in orderedItems)
            {
                totalPrice = totalPrice + (item.Price * item.Quantity);
            };

            OrderViewModel viewModel = new OrderViewModel()
            {
                CustomerId = 1,
                /*CustomerId = customerId,*/
                OrderedItems = orderedItems,
                TotalPrice = totalPrice,
            };

            return View(viewModel);
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create()
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

            double totalPrice = 0;
            foreach (BasketItemDto item in basketItems)
            {
                totalPrice = totalPrice + (item.Price * item.Quantity);
            };

            try
            {
                OrderDto newOrder = new OrderDto
                {
                    CustomerId = 1,
                   /* CustomerId = customerId,*/
                   Date = DateTime.Now,
                   OrderedItems = basketItems.Select(i => new OrderedItemDto
                   {
                       ProductId = i.ProductId,
                       ProductName = i.ProductName,
                       Quantity = i.Quantity,
                       Price = i.Price,
                   }).ToList(),
                   TotalPrice = totalPrice
                };

                await _orderFacade.NewOrder(newOrder);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Order Facade");
            }

            return RedirectToAction("index", "basket");
        }

        // GET: Order/History
        public async Task<IActionResult> History()
        {
            IEnumerable<OrderHistoryDto> orderHistory = null;
            try
            {
                orderHistory = await _orderFacade.GetOrders(1);
                /*orderHistory = await _orderFacade.GetOrders(customerId);*/
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Order Facade");
                orderHistory = null;
            }

            IEnumerable<OrderHistoryViewModel> viewModel = orderHistory.Select(o => new OrderHistoryViewModel
            {
                OrderId = o.OrderId,
                Date = o.Date,
                TotalPrice = o.TotalPrice,
            });

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int orderId)
        {
            OrderDto order = null;
            try
            {
                order = await _orderFacade.GetOrder(orderId);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Order Facade");
                order = null;
            }

            IEnumerable<ReviewDto> reviews = null;
            try
            {
                reviews = await _reviewFacade.GetCustomerReviews(1);
                /*reviews = await _reviewFacade.GetCustomerReviews(customerId);*/
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Review Facade");
                reviews = null;
            }

            List<OrderedItemViewModel> orderedItems = order.OrderedItems.Select(b => new OrderedItemViewModel
            {
                ProductId = b.ProductId,
                Quantity = b.Quantity,
                Price = b.Price,
                ProductName = b.ProductName,
            }).ToList();

            foreach (var item in orderedItems)
            {
                if(reviews.Any(r => r.ProductId == item.ProductId))
                {
                    item.hasReviewed = true;
                }
            }

            OrderViewModel viewModel = new OrderViewModel
            {
                OrderId = order.OrderId,
                Date = order.Date,
                OrderedItems = orderedItems,
                TotalPrice = order.TotalPrice,
            };

            return View(viewModel);
        }
    }
}