using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Order
{
    public class OrderFacade : IOrderFacade
    {
        private readonly ILogger<OrderDto> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public OrderFacade(ILogger<OrderDto> logger,
                              IHttpClientFactory clientFactory,
                              HttpClient client)
        {
            _logger = logger;
            _clientFactory = clientFactory;

            client.BaseAddress = new System.Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _client = client;
        }

        // POST: api/Order
        [HttpPost("api/Order")]
        public async Task<OrderDto> PostOrder(OrderDto newOrder)
        {
            var response = await _client.PostAsJsonAsync("api/Order", newOrder);
            response.EnsureSuccessStatusCode();

            return newOrder;
        }

        // GET: api/Order/X
        [HttpGet("api/Order")]
        public async Task<OrderDto> GetOrder(int orderId)
        {
            var response = await _client.GetAsync("api/Order/" + orderId);
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
        public async Task<List<OrderHistoryDto>> GetOrders(int customerId)
        {
            var response = await _client.GetAsync("api/Order?customerId=" + customerId);
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
