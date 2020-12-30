using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customer.Web.Services.Customer
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        public string GivenName { get; set; }

        [Required]
        public string FamilyName { get; set; }

        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        public string Town { get; set; }

        public string State { get; set; }

        public string AreaCode { get; set; }

        public string Country { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }

        public bool RequestedDeletion { get; set; }

        public bool CanPurchase { get; set; }

        public string Password { get; set; }
    }
}
