using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Basket
{
    public class BasketFacade : IBasketFacade
    {
        private readonly ILogger<BasketItemDto> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public BasketFacade(ILogger<BasketItemDto> logger,
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

        // GET: api/Basket/X
        [HttpGet("api/Basket")]
        public async Task<List<BasketItemDto>> GetBasket(int customerId)
        {
            var response = await _client.GetAsync("api/Basket/" + customerId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var basket = await response.Content.ReadAsAsync<List<BasketItemDto>>();

            return basket;
        }

        // POST: api/Basket
        [HttpPost("api/Basket")]
        public async Task<BasketItemDto> PostItem(BasketItemDto basketItem)
        {
            var response = await _client.PostAsJsonAsync("api/Basket", basketItem);
            response.EnsureSuccessStatusCode();

            return basketItem;
        }

        // PUT: api/Basket/X
        [HttpPut("api/Basket")]
        public async Task<BasketItemDto> PutItem(int customerId, BasketItemDto basketItem)
        {
            var response = await _client.PutAsJsonAsync("/api/Basket/" + customerId, basketItem);
            response.EnsureSuccessStatusCode();

            return basketItem;
        }

        // DELETE: api/Basket?customerId=X&productId=X
        [HttpDelete("api/Basket")]
        public async Task<BasketItemDto> DeleteItem(int customerId, int productId)
        {
            var response = await _client.DeleteAsync("/api/Basket?customerId=" + customerId
                                                               + "&productId=" + productId);

            return null;
        }
    }
}
