using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Web.Services.Basket;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Order
{
    public class OrderFacade : ControllerBase, IOrderFacade
    {
        private readonly ILogger<OrderDto> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public OrderFacade(ILogger<OrderDto> logger,
                              IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        // POST: api/Order
        [HttpPost("api/Order")]
        public async Task<OrderDto> NewOrder(OrderDto newOrder)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.PostAsJsonAsync("https://customerorderingthamco.azurewebsites.net/Order", newOrder);
            response.EnsureSuccessStatusCode();

            return newOrder;
        }

        // GET: api/Order/X
        [HttpGet("api/Order")]
        public async Task<OrderDto> GetOrder(int orderId)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.GetAsync("https://customerorderingthamco.azurewebsites.net/Order/" + orderId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();

            return order;
        }

        // GET: api/Order?customerId=X
        [HttpGet("api/Order")]
        public async Task<IEnumerable<OrderHistoryDto>> GetOrders(int customerId)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.GetAsync("https://customerorderingthamco.azurewebsites.net/Order?customerId=" + customerId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var orders = await response.Content.ReadAsAsync<List<OrderHistoryDto>>();

            return orders;
        }
    }
}
