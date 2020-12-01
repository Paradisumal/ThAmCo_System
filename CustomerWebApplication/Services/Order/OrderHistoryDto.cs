using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Order
{
    public class OrderHistoryDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }  

        public DateTime Date { get; set; }

        public double TotalPrice { get; set; }
    }
}
