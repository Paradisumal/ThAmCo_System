using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.Services.Review
{
    public class ReviewDto
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
