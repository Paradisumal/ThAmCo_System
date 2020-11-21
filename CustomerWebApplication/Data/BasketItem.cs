using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Data
{
    public class BasketItem
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set;}
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
