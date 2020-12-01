using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        
        public int CustomerId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<OrderedItemDto> OrderedItems { get; set; }
        
        public double TotalPrice { get; set; }
    }
}
