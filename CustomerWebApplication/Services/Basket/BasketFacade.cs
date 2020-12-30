using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Basket
{


    public class BasketFacade : ControllerBase, IBasketFacade
    {
        private readonly ILogger<BasketItemDto> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public BasketFacade(ILogger<BasketItemDto> logger,
                              IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        // GET: api/Basket/X
        public async Task<IEnumerable<BasketItemDto>> GetBasket(int customerId)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.GetAsync("https://customerorderingthamco.azurewebsites.net/Basket/" + customerId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            var basket = await response.Content.ReadAsAsync<List<BasketItemDto>>();

            return basket;
        }

        // POST: api/Basket
        public async Task<BasketItemDto> AddItem(BasketItemDto newItem)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.PostAsJsonAsync("https://customerorderingthamco.azurewebsites.net/Basket", newItem);
            response.EnsureSuccessStatusCode();

            return newItem;
        }

        // PUT: api/Basket/X
        public async Task<BasketItemDto> UpdateItem(int customerId, BasketItemDto updatedItem)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.PutAsJsonAsync("https://customerorderingthamco.azurewebsites.net/Basket/" + customerId, updatedItem);
            response.EnsureSuccessStatusCode();

            return updatedItem;
        }

        // DELETE: api/Basket?customerId=X&productId=X
        public async Task<BasketItemDto> RemoveItem(int customerId, int productId)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await client.DeleteAsync("https://customerorderingthamco.azurewebsites.net/Basket?customerId=" + customerId
                                                               + "&productId=" + productId);
            return null;
        }
    }
}
