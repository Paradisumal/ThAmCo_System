using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public bool CanPurchase { get; set; }
        public bool IsDeleted { get; set; }
    }
}
