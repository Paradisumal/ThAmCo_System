using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Customer.Facade.Models;

namespace Customer.Facade
{
    public class FakeCustomerFacade : ICustomerFacade
    {
        public List<CustomerDto> _customers;

        public FakeCustomerFacade()
        {
            _customers = new List<CustomerDto>()
            {
                new CustomerDto() { CustomerId = 1, GivenName = "Adam", FamilyName = "Appleton", AddressOne = "666 Orchard Terrace", AddressTwo = "Garden of Eden", Town = "Baghdad",
                    State = "Baghdad", AreaCode = "142857", Country = "Iraq", EmailAddress = "first_man@earth.com", TelephoneNumber = "9876 5432", RequestedDeletion = false, CanPurchase = true },
                new CustomerDto() { CustomerId = 2, GivenName = "Benjamin", FamilyName = "Frankston", AddressOne = "100 Buck Boulevard", AddressTwo = "Longwood", Town = "Boston",
                    State = "Massachusetts", AreaCode = "314159",  Country = "United States", EmailAddress = "Pencil_President@states.com", TelephoneNumber = "9765 4321", RequestedDeletion = false,
                    CanPurchase = true },
                new CustomerDto() { CustomerId = 3, GivenName = "Christopher", FamilyName = "Columbo", AddressOne = "360 Seaside Alley", AddressTwo = "Wharf District", Town = "Genoa",
                    State = "Genoa", AreaCode = "161803",  Country = "Italy", EmailAddress = "exploring@sea.com", TelephoneNumber = "9654 3218", RequestedDeletion = true, CanPurchase = false },
                new CustomerDto() { CustomerId = 4, GivenName = "Donald", FamilyName = "Plump", AddressOne = "911 Wall Street", AddressTwo = "Manhattan", Town = "New York",
                    State = "New York", AreaCode = "141421",  Country = "United States", EmailAddress = "leader@freeworld.com", TelephoneNumber = "9543 2187", RequestedDeletion = false, CanPurchase = false },
                new CustomerDto() { CustomerId = 5, GivenName = "Eric", FamilyName = "Stony", AddressOne = "53 Denwa Lane", AddressTwo = "Atomic Aftermath", Town = "Tokyo",
                    State = "Kanto", AreaCode = "271828",  Country = "Japan", EmailAddress = "calling@phone.com", TelephoneNumber = "9432 1876", RequestedDeletion = true, CanPurchase = true },

            };

        }

        public Task<CustomerDto> PostCustomer(CustomerDto newCustomer)
        {
            _customers.Add(newCustomer);

            return Task.FromResult(newCustomer);
        }

        public Task<CustomerDto> GetCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            return Task.FromResult(customer);
        }

        public Task<CustomerDto> PutCustomer(int id, CustomerDto updatedCustomer)
        {
            CustomerDto customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                customer.GivenName = updatedCustomer.GivenName;
                customer.FamilyName = updatedCustomer.FamilyName;
                customer.AddressOne = updatedCustomer.AddressOne;
                customer.AddressTwo = updatedCustomer.AddressTwo;
                customer.Town = updatedCustomer.Town;
                customer.State = updatedCustomer.State;
                customer.AreaCode = updatedCustomer.AreaCode;
                customer.Country = updatedCustomer.Country;
                customer.TelephoneNumber = updatedCustomer.TelephoneNumber;
            };

            return Task.FromResult(customer);
        }

        public Task<CustomerDto> DeleteCustomer(int id)
        {
            CustomerDto customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }

            return Task.FromResult(customer);
        }
    }
}
