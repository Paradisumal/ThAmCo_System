using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.ViewModels
{
    public class OrderHistoryViewModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public double TotalPrice { get; set; }
    }
}
