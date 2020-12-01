using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Customer.Web.Services.Customer;
using Customer.Web.ViewModels;
using CustomerWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Customer.Tests.AccountTests
{
    [TestClass]
    class AccountControllerTests
    {
        [TestMethod]
        public async Task MethodBeingTested_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task Constructor_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task RegisterGet_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task RegisterPost_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task LoginGet_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task LoginPost_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task Logout_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task AccessDenied_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task GetAccountDetails_ShouldReturnCorrectViewModel()
        {
            // Arrange

            CustomerDto customer = new CustomerDto()
            {
                CustomerId = 3,
                GivenName = "Christopher",
                FamilyName = "Columbo",
                AddressOne = "360 Seaside Alley",
                AddressTwo = "Wharf District",
                Town = "Genoa",
                State = "Genoa",
                AreaCode = "161803",
                Country = "Italy",
                EmailAddress = "exploring@sea.com",
                TelephoneNumber = "9654 3218",
                RequestedDeletion = true,
                CanPurchase = false
            };

            List<CustomerDto> customers = new List<CustomerDto>()
            {
                new CustomerDto() { CustomerId = 1, GivenName = "Adam", FamilyName = "Appleton", AddressOne = "666 Orchard Terrace", AddressTwo = "Garden of Eden", Town = "Baghdad",
                    State = "Baghdad", AreaCode = "142857", Country = "Iraq", EmailAddress = "first_man@earth.com", TelephoneNumber = "9876 5432", RequestedDeletion = false, CanPurchase = true },
                new CustomerDto() { CustomerId = 2, GivenName = "Benjamin", FamilyName = "Frankston", AddressOne = "100 Buck Boulevard", AddressTwo = "Longwood", Town = "Boston",
                    State = "Massachusetts", AreaCode = "314159",  Country = "United States", EmailAddress = "Pencil_President@states.com", TelephoneNumber = "9765 4321", RequestedDeletion = false,
                    CanPurchase = true },
                customer,
                new CustomerDto() { CustomerId = 4, GivenName = "Donald", FamilyName = "Plump", AddressOne = "911 Wall Street", AddressTwo = "Manhattan", Town = "New York",
                    State = "New York", AreaCode = "141421",  Country = "United States", EmailAddress = "leader@freeworld.com", TelephoneNumber = "9543 2187", RequestedDeletion = false, CanPurchase = false },
                new CustomerDto() { CustomerId = 5, GivenName = "Eric", FamilyName = "Stony", AddressOne = "53 Denwa Lane", AddressTwo = "Atomic Aftermath", Town = "Tokyo",
                    State = "Kanto", AreaCode = "271828",  Country = "Japan", EmailAddress = "calling@phone.com", TelephoneNumber = "9432 1876", RequestedDeletion = true, CanPurchase = true },
            };

            var customerId = 1;

            var facade = new FakeCustomerFacade
            {
                _customers = customers
            };

            ILogger dummyLogger = new ILogger();

            var controller = new AccountController(dummyLogger, facade);

            // Act
            var result = await controller.Details(customerId);

            //Assert
            Assert.IsNotNull(result);
            var objResult = result as ViewResult;
            Assert.IsNotNull(objResult);
            var customerDetails = objResult.Model as CustomerViewModel;
            Assert.IsNotNull(customerDetails);

            Assert.AreEqual(customerDetails.CustomerId, customer.CustomerId);
            Assert.AreEqual(customerDetails.GivenName, customer.GivenName);
            Assert.AreEqual(customerDetails.FamilyName, customer.FamilyName);
            Assert.AreEqual(customerDetails.AddressOne, customer.AddressOne);
            Assert.AreEqual(customerDetails.AddressTwo, customer.AddressTwo);
            Assert.AreEqual(customerDetails.Town, customer.Town);
            Assert.AreEqual(customerDetails.State, customer.State);
            Assert.AreEqual(customerDetails.AreaCode, customer.AreaCode);
            Assert.AreEqual(customerDetails.Country, customer.Country);
            Assert.AreEqual(customerDetails.EmailAddress, customer.EmailAddress);
            Assert.AreEqual(customerDetails.TelephoneNumber, customer.TelephoneNumber);
        }

        [TestMethod]
        public async Task UpdatedGet_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task UpdatePut_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task DeleteGet_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public async Task DeletePost_ExpectedResult()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
