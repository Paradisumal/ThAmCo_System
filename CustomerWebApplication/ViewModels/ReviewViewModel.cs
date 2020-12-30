using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Web.ViewModels
{
    public class ReviewViewModel
    {
        public int ProductId { get; set; }

        [DisplayName("Product")]
        public String ProductName { get; set; }

        [DisplayName("Reviewer")]
        public string CustomerName { get; set; }

        public int Rating { get; set; }

        [DisplayName("Review")]
        public string ReviewText { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
