using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ILogger _logger;
        private readonly IBasketFacade _basketFacade;

        public BasketController(ILogger<BasketController> logger,
                                IBasketFacade basketFacade)
        {
            _logger = logger;
            _basketFacade = basketFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Items()
        {


            return View();
        }
    }
}