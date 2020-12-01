using System;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Facade.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Facade
{
    public interface ICustomerFacade
    {
        Task<CustomerDto> PostCustomer(CustomerDto newCustomer);
        Task<CustomerDto> GetCustomer(int id);
        Task<CustomerDto> PutCustomer(int id, CustomerDto updatedCustomer);
        Task<CustomerDto> DeleteCustomer(int id);
    }
}
