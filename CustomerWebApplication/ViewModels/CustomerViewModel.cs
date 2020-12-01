using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        [ReadOnly(true)]
        [DisplayName("Given Name")]
        public string GivenName { get; set; }

        [Required]
        [ReadOnly(true)]
        [DisplayName("Family Name")]
        public string FamilyName { get; set; }

        [DisplayName("Address Line 1")]
        public string AddressOne { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressTwo { get; set; }

        public string Town { get; set; }

        public string State { get; set; }

        [DisplayName("Area Code")]
        public string AreaCode { get; set; }

        public string Country { get; set; }

        [Required]
        [ReadOnly(true)]
        [DisplayName("Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("Phone")]
        public string TelephoneNumber { get; set; }
    }
}
