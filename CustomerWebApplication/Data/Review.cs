using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.Data
{
    public class Review
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public bool isVisible { get; set; }
    }
}
