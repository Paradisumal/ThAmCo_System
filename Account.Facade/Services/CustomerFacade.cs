using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Customer.Facade.Models;
using Microsoft.AspNetCore.Mvc;


namespace Customer.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly HttpClient _client;

        public CustomerFacade(HttpClient client)
        {
            client.BaseAddress = new System.Uri("");
            client.Timeout  = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _client = client;
        }


        public async Task<CustomerDto> PostCustomer(CustomerDto newCustomer)
        {

            var response = await _client.PostAsJsonAsync("api/Customer", newCustomer);
            response.EnsureSuccessStatusCode();

            return newCustomer;
        }

        public async Task<CustomerDto> GetCustomer(int id)
        {
            var response = await _client.GetAsync("api/Customer/" + id);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        public async Task<CustomerDto> PutCustomer(int id, CustomerDto updatedCustomer)
        {
            var response = await _client.PutAsJsonAsync("/api/Customer/" + id, updatedCustomer);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();

            return updatedCustomer;
        }

        public async Task<CustomerDto> DeleteCustomer(int id)
        {
            var response = await _client.DeleteAsync("/api/Customer/" + id);

            return ???;
        }
    }
}
