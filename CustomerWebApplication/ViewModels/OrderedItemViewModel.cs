using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.ViewModels
{
    public class OrderedItemViewModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ProductName { get; set; }

        public bool hasReviewed { get; set; }
    }
}
