using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Web.Services.Customer
{
    public interface ICustomerFacade
    {
        Task<CustomerDto> Register(CustomerDto newCustomer);
        Task<AccountDto> Login(AccountDto account);
        Task<AccountDto> Logout();
        Task<CustomerDto> GetCustomer(int customerId);
        Task<CustomerDto> PutCustomer(int customerId, CustomerDto updatedCustomer);
        Task<CustomerDto> DeleteCustomer(int customerId);
    }
}
