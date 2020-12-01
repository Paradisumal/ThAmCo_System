using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IOrderFacade _orderFacade;

        public OrderController(ILogger<OrderController> logger,
                                IOrderFacade orderFacade)
        {
            _logger = logger;
            _orderFacade = orderFacade;
        }

        // GET: Order/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDto order)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("items", "basket");
            }

            return View();
        }

        // GET: Order/History
        public async Task<IActionResult> History()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}