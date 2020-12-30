using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Customer.Web.Services.Order;

namespace Customer.Web.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<OrderedItemViewModel> OrderedItems { get; set; }

        public double TotalPrice { get; set; }
    }
}
