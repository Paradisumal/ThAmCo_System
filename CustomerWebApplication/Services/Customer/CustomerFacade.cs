using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Customer.Web.Services.Customer
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ILogger<CustomerDto> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public CustomerFacade(ILogger<CustomerDto> logger,
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

        // POST: api/Customer
        [HttpPost("api/Customer")]
        public async Task<CustomerDto> PostCustomer(CustomerDto newCustomer)
        {
            var response = await _client.PostAsJsonAsync("api/Customer", newCustomer);
            response.EnsureSuccessStatusCode();

            return newCustomer;
        }

        // GET: api/Customer/X
        [HttpGet("api/Customer")]
        public async Task<CustomerDto> GetCustomer(int customerId)
        {
            /*var client = _clientFactory.CreateClient();

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);*/

            var response = await _client.GetAsync("api/Customer/" + customerId);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();

            return customer;
        }

        // PUT: api/Customer/X
        [HttpPut("api/Customer")]
        public async Task<CustomerDto> PutCustomer(int customerId, CustomerDto updatedCustomer)
        {
            var response = await _client.PutAsJsonAsync("/api/Customer/" + customerId, updatedCustomer);
            response.EnsureSuccessStatusCode();

            return updatedCustomer;
        }

        // DELETE: api/Customer/X
        [HttpDelete("api/Customer")]
        public async Task<CustomerDto> DeleteCustomer(int customerId)
        {
            var response = await _client.DeleteAsync("/api/Customer/" + customerId);

            return null;
        }
    }
}
